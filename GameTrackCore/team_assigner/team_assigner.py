from sklearn.cluster import KMeans
import numpy as np


class TeamAssigner:
    def __init__(self, overrides=None):
        self.team_colors = {}
        self.player_team_dict = {}
        self.overrides = overrides or {}
        self.kmeans = None

    def get_clustering_model(self, image):
        image_2d = image.reshape(-1, 3)
        kmeans = KMeans(n_clusters=2, init="k-means++", n_init=10, random_state=0)
        kmeans.fit(image_2d)
        return kmeans

    def get_player_color(self, frame, bbox):
        h, w = frame.shape[:2]
        x1, y1, x2, y2 = map(int, bbox)

        x1 = max(0, min(x1, w - 1))
        x2 = max(0, min(x2, w))
        y1 = max(0, min(y1, h - 1))
        y2 = max(0, min(y2, h))

        if x2 <= x1 or y2 <= y1:
            return None

        image = frame[y1:y2, x1:x2]
        if image.size == 0 or image.shape[0] < 2 or image.shape[1] < 2:
            return None

        top_half = image[: max(1, image.shape[0] // 2), :]
        if top_half.size == 0:
            return None

        kmeans = self.get_clustering_model(top_half)

        labels = kmeans.labels_
        clustered = labels.reshape(top_half.shape[0], top_half.shape[1])

        corner_clusters = [clustered[0, 0], clustered[0, -1], clustered[-1, 0], clustered[-1, -1]]
        non_player_cluster = max(set(corner_clusters), key=corner_clusters.count)
        player_cluster = 1 - non_player_cluster

        player_color = kmeans.cluster_centers_[player_cluster]
        return player_color

    def assign_team_color(self, frame, player_detections):
        player_colors = []
        for _, det in player_detections.items():
            bbox = det["bbox"]
            color = self.get_player_color(frame, bbox)
            if color is not None:
                player_colors.append(color)

        if len(player_colors) < 2:
            raise RuntimeError("Not enough valid player crops to estimate team colors (need >= 2).")

        kmeans = KMeans(n_clusters=2, init="k-means++", n_init=10, random_state=0)
        kmeans.fit(np.array(player_colors))

        self.kmeans = kmeans
        self.team_colors[1] = kmeans.cluster_centers_[0]
        self.team_colors[2] = kmeans.cluster_centers_[1]

    def get_player_team(self, frame, player_bbox, player_id):
        if player_id in self.player_team_dict:
            return self.player_team_dict[player_id]

        if player_id in self.overrides:
            team_id = self.overrides[player_id]
            self.player_team_dict[player_id] = team_id
            return team_id

        if self.kmeans is None:
            raise RuntimeError("TeamAssigner.kmeans is not initialized. Call assign_team_color() first.")

        player_color = self.get_player_color(frame, player_bbox)
        if player_color is None:
            # fallback: if crop failed, assign the most common team so far, else 1
            team_id = self.player_team_dict[next(iter(self.player_team_dict))] if self.player_team_dict else 1
            self.player_team_dict[player_id] = team_id
            return team_id

        team_id = int(self.kmeans.predict(player_color.reshape(1, -1))[0]) + 1
        self.player_team_dict[player_id] = team_id
        return team_id
