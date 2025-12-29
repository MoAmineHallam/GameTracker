from ultralytics import YOLO



# Load the YOLO model
model = YOLO('yolo11x.pt')




# Run the model's prediction with correct arguments
results = model.predict(
    'input videos/test1.mp4',  # Path to the input video
    save=True  # Save output
)
print(model)
print(results[0])

# Print each detected box
for box in results[0].boxes:
    print(box)
