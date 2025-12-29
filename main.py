from utils import read_video, save_video
from tracker import Tracker
import numpy as np
from team_assigner import TeamAssigner
from player_ball_assigner import PlayerBallAssigner
from camera_movement_estimator import CameraMovementEstimator
from view_transformer import ViewTransformer
from speed_and_distance_estimator import SpeedAndDistance_Estimator
import os
import argparse
import hashlib

def _safe_stub_file(stubs_dir: str, video_path: str, name: str) -> str:
    os.makedirs(stubs_dir, exist_ok=True)
    key = hashlib.md5(os.path.abspath(video_path).encode("utf-8")).hexdigest()[:10]
    return os.path.join(stubs_dir, f"{name}_{key}.pkl")

def parse_args():
    parser = argparse.ArgumentParser(description="Football player & ball tracking")

    parser.add_argument(
        "--video",
        type=str,
        required=True,
        help="Path to input video"
    )

    parser.add_argument(
        "--model",
        type=str,
        default=os.path.join("models", "yolo.pt"),
        help="Path to YOLO model weights"
    )

    parser.add_argument(
        "--output",
        type=str,
        default=os.path.join("output", "output.avi"),
        help="Path to output video"
    )

    parser.add_argument(
        "--stubs",
        type=str,
        default="stubs",
        help="Directory for cached detections"
    )

    parser.add_argument(
        "--use-stubs",
        action="store_true",
        help="Use cached detections if available"
    )

    return parser.parse_args()


def main():
    args = parse_args()

    video_path = args.video
    model_path = args.model
    output_path = args.output
    stubs_dir = args.stubs
    use_stubs = args.use_stubs

    print(f"[INFO] video:  {video_path}")
    print(f"[INFO] model:  {model_path}")
    print(f"[INFO] output: {output_path}")
    print(f"[INFO] stubs:  {stubs_dir} (use_stubs={use_stubs})")

    # Validate inputs
    if not os.path.isfile(video_path):
        raise FileNotFoundError(f"Input video not found: {video_path}")

    if not os.path.isfile(model_path):
        raise FileNotFoundError(f"Model weights not found: {model_path}")

    # Ensure output directory exists
    out_dir = os.path.dirname(output_path) or "."
    os.makedirs(out_dir, exist_ok=True)

    # Read video
    video_frames = read_video(video_path)
    if video_frames is None or len(video_frames) == 0:
        raise RuntimeError("Failed to read video frames (read_video returned empty).")

    # Tracking (detections + tracks)
    tracker = Tracker(model_path)

    # If your Tracker expects a *file path* for a stub, create a deterministic stub file name.
    # If it expects a *directory*, pass the directory. Your original code implies a directory.
    tracks = tracker.get_object_tracks(
        video_frames,
        read_from_stub=use_stubs,
        stub_path=stubs_dir
    )

    tracker.add_position_to_tracks(tracks)

    # Camera movement
    camera_movement_estimator = CameraMovementEstimator(video_frames[0])
    camera_stub = _safe_stub_file(stubs_dir, video_path, "camera_movement")

    camera_movement_per_frame = camera_movement_estimator.get_camera_movement(
        video_frames,
        read_from_stub=use_stubs,
        stub_path=camera_stub
    )
    camera_movement_estimator.add_adjust_positions_to_tracks(tracks, camera_movement_per_frame)

    # View transform
    view_transformer = ViewTransformer()
    view_transformer.add_transformed_position_to_tracks(tracks)

    # Interpolate ball positions
    tracks["ball"] = tracker.interpolate_ball_positions(tracks["ball"])

    # Speed & distance
    speed_and_distance_estimator = SpeedAndDistance_Estimator()
    speed_and_distance_estimator.add_speed_and_distance_to_tracks(tracks)

    # Team assignment
    team_assigner = TeamAssigner()
    team_assigner.assign_team_color(video_frames[0], tracks["players"][0])

    for frame_num, player_track in enumerate(tracks["players"]):
        for player_id, track in player_track.items():
            team = team_assigner.get_player_team(
                video_frames[frame_num],
                track["bbox"],
                player_id
            )
            tracks["players"][frame_num][player_id]["team"] = team
            tracks["players"][frame_num][player_id]["team_color"] = team_assigner.team_colors[team]

    # Ball acquisition
    player_assigner = PlayerBallAssigner()
    team_ball_control = []

    for frame_num, player_track in enumerate(tracks["players"]):
        ball_bbox = tracks["ball"][frame_num][1]["bbox"]
        assigned_player = player_assigner.assign_ball_to_player(player_track, ball_bbox)

        if assigned_player != -1:
            tracks["players"][frame_num][assigned_player]["has_ball"] = True
            team_ball_control.append(tracks["players"][frame_num][assigned_player]["team"])
        else:
            # First frame edge case: no previous control yet
            team_ball_control.append(team_ball_control[-1] if len(team_ball_control) > 0 else 0)

    team_ball_control = np.array(team_ball_control)

    # Draw annotations
    output_video_frames = tracker.draw_annotations(video_frames, tracks, team_ball_control)
    output_video_frames = camera_movement_estimator.draw_camera_movement(
        output_video_frames, camera_movement_per_frame
    )
    speed_and_distance_estimator.draw_speed_and_distance(output_video_frames, tracks)

    # Save video to the user-chosen output path
    save_video(output_video_frames, output_path)
    print(f"[DONE] saved: {output_path}")


if __name__ == "__main__":
    main()
