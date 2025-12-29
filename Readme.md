# Football Player & Ball Tracking with YOLO11

This repository contains the code, experiments, and tooling for a thesis project on automatic player, ball, and team analysis in football broadcast videos using deep learning–based detection and multi-object tracking.

The system integrates a YOLO-based detector with tracking, camera motion compensation, team color clustering, and kinematic analysis to produce annotated football match videos with player identities, team affiliation, ball possession, and movement statistics.

The project is designed to be modular, reproducible, and research-oriented rather than a production or real-time system.

---

## Project Overview

Given a broadcast football video as input, the pipeline produces an annotated output video containing:

- Player, referee, and ball detection  
- Persistent player identities via multi-object tracking  
- Team assignment using jersey color clustering  
- Ball possession estimation  
- Camera motion estimation and compensation  
- Player speed and distance estimation  
- Visual overlays (IDs, team colors, possession statistics, motion indicators)

The focus is on analysis and experimentation, not deployment.

---

## Repository Structure

.
├── backend/
│ ├── core/
│ │ ├── tracker.py
│ │ ├── team_assigner.py
│ │ ├── player_ball_assigner.py
│ │ ├── camera_movement_estimator.py
│ │ ├── view_transformer.py
│ │ ├── speed_and_distance_estimator.py
│ │ └── utils.py
│ ├── main.py
│ ├── requirements.txt
│ └── notebooks/
│ └── football_training_yolo11_reproducible.ipynb
│
├── ui/
│ ├── FinalProjectUI.sln
│ └── FinalProjectUI/
│
├── assets/
│ └── demo_images/
│
└── README.md

yaml
Copy code

---

## Backend: Python Pipeline

### Requirements

Create a Python environment and install dependencies:

pip install -r backend/requirements.txt

yaml
Copy code

Core dependencies include:

- ultralytics  
- supervision  
- opencv-python  
- numpy  
- pandas  
- scikit-learn  

---

### Running the Backend (CLI)

The backend is executed via a command-line interface.

python backend/main.py
--video path/to/input_video.mp4
--output output/output.avi

sql
Copy code

Optional arguments:

- --model : path to YOLO weights  
- --stubs : directory for cached intermediate results  
- --use-stubs : reuse cached detections and camera motion  

Example:

python backend/main.py
--video data/match.mp4
--output output/annotated_match.avi
--use-stubs

yaml
Copy code

---

### Output

The output video includes:

- Elliptical markers for players and referees  
- Ball indicators  
- Persistent player IDs  
- Team color coding  
- Ball possession statistics  
- Camera motion visualization  
- Speed and distance overlays  

---

## Model Training

Model training is documented in:

backend/notebooks/football_training_yolo11_reproducible.ipynb

yaml
Copy code

This notebook:

- Preserves all training code exactly as executed  
- Records environment assumptions and parameters  
- Allows full reproduction of the trained detector  

Training artifacts (e.g. runs/, checkpoints) are not included in this repository to keep it lightweight.

---

## User Interface (Windows Forms)

A Windows Forms application is provided to:

- Load an input video  
- Run the Python backend  
- Preview and export the annotated result  

### UI Requirements

- Windows  
- .NET  
- Python available in system PATH (or configured via environment variables)  
- VLC Media Player (required by LibVLCSharp)  

The UI invokes the backend via CLI and does not embed Python logic directly.

---

## Reproducibility Notes

- No absolute paths are hard-coded  
- All model execution is parameterized  
- Cached stubs are optional and deterministic per video  
- NuGet and pip dependencies are restored automatically  

---

## Limitations

This project has known limitations:

- Team assignment relies on jersey color clustering and may fail under similar colors or heavy occlusion  
- Camera calibration is approximate and assumes a broadcast-style viewpoint  
- Ball possession is inferred heuristically and may be noisy in crowded scenes  
- The system is not designed for real-time deployment  

---

## License

This project is intended for academic and research use.

Dataset licenses and model usage terms must be respected by downstream users.

---

## Author

Mohamed Amine Hallam
