Football Player \& Ball Tracking with YOLO11



This repository contains the code and experiments for a thesis project on automatic player, ball, and team analysis in football videos using deep learning–based detection and multi-object tracking.



The system combines a YOLO-based detector with tracking, camera motion compensation, team color clustering, and kinematic analysis to produce annotated match videos with player identities, team possession, and movement statistics.



Project Overview



The pipeline takes a broadcast football video as input and produces an annotated output video containing:



Player, referee, and ball detection



Persistent player IDs via tracking



Team assignment using jersey color clustering



Ball possession estimation



Camera motion estimation and compensation



Speed and distance estimation per player



Visual overlays (IDs, possession statistics, movement indicators)



The project is designed to be reproducible, modular, and suitable for research experimentation.



Repository Structure

.

├── backend/

│   ├── core/

│   │   ├── tracker.py

│   │   ├── team\_assigner.py

│   │   ├── player\_ball\_assigner.py

│   │   ├── camera\_movement\_estimator.py

│   │   ├── view\_transformer.py

│   │   ├── speed\_and\_distance\_estimator.py

│   │   └── utils.py

│   ├── main.py

│   ├── requirements.txt

│   └── notebooks/

│       └── football\_training\_yolo11\_reproducible.ipynb

│

├── ui/

│   ├── FinalProjectUI.sln

│   └── FinalProjectUI/

│

├── assets/

│   └── demo\_images/

│

└── README.md



Backend: Python Pipeline

Requirements



Create a Python environment and install dependencies:



pip install -r backend/requirements.txt





Core dependencies include:



ultralytics



supervision



opencv-python



numpy



pandas



scikit-learn



Running the Backend (CLI)



The backend is executed via a command-line interface.



python backend/main.py \\

&nbsp; --video path/to/input\_video.mp4 \\

&nbsp; --output output/output.avi





Optional arguments:



--model : path to YOLO weights



--stubs : directory for cached intermediate results



--use-stubs : reuse cached detections and camera motion



Example:



python backend/main.py \\

&nbsp; --video data/match.mp4 \\

&nbsp; --output output/annotated\_match.avi \\

&nbsp; --use-stubs



Output



The output video contains:



Elliptical markers for players and referees



Ball indicators



Player IDs



Team color coding



Ball possession statistics



Camera motion visualization



Speed and distance overlays



Model Training



Model training is documented in:



backend/notebooks/football\_training\_yolo11\_reproducible.ipynb





This notebook:



preserves all training code exactly as executed



records environment assumptions and parameters



allows full reproduction of the trained detector



Training artifacts (e.g. runs/) are not included in this repository to keep it lightweight.



User Interface (Windows Forms)



A Windows Forms application is provided to:



load an input video



run the Python backend



preview and export the annotated result



UI Requirements



Windows



.NET



Python available in system PATH (or configured via environment variable)



VLC Media Player (required by LibVLCSharp)



The UI invokes the backend via CLI and does not embed Python logic directly.



Reproducibility Notes



No absolute paths are hard-coded.



All model execution is parameterized.



Cached stubs are optional and deterministic per video.



NuGet and pip dependencies are restored automatically.



Limitations



This project has known limitations:



Team assignment relies on jersey color clustering and may fail under similar colors or heavy occlusion.



Camera calibration is approximate and assumes a broadcast-style viewpoint.



Ball possession is inferred heuristically and may be noisy in crowded scenes.



The system is designed for research and analysis, not real-time deployment.



License



This project is intended for academic and research use.

Dataset licenses and model usage terms must be respected by downstream users.



Author



Mohamed Amine Hallam

