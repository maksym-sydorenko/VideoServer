from fastapi import FastAPI, Request, UploadFile, File
from fastapi.responses import PlainTextResponse
from fastapi.responses import JSONResponse
from PIL import Image
import uvicorn
import os
from datetime import datetime
from io import BytesIO
import logging

from ultralytics import YOLO

app = FastAPI()
log = logging.getLogger("server")
logging.basicConfig(level=logging.INFO)

# Path for save 
base_path = os.path.join(os.getcwd(), datetime.now().strftime("%Y%m%d"))
os.makedirs(base_path, exist_ok=True)

# Load model
model = YOLO("yolov8n.pt")  # lightweight, fast

@app.post("/upload")
async def upload_image(request: Request):
    try:
        content_type = request.headers.get("content-type", "")
        if "multipart/form-data" not in content_type:
            return PlainTextResponse("Invalid content type", status_code=400)

        form = await request.form()
        file = next(iter(form.values()))
        contents = await file.read()

        image = Image.open(BytesIO(contents))
        if image.mode == "RGBA":
            image = image.convert("RGB")

        results = model(image)

        # for debug
        #f_name = f"{file.filename}.jpg"
        #filepath = os.path.join(base_path, f_name)
        #results[0].save(filename=filepath)

        detections = []
        for box in results[0].boxes:
            cls_id = int(box.cls[0])
            label = results[0].names[cls_id]
            conf = float(box.conf[0])
            xyxy = box.xyxy[0].tolist()
            detections.append({
                "label": label,
                "confidence": round(conf, 2),
                "box": [round(x, 1) for x in xyxy]
            })

        return JSONResponse({
            "filename": file.filename,
            "detections": detections
        })

    except Exception as e:
        log.error(f"Error: {e}")
        return PlainTextResponse("Error processing file", status_code=500)
 
@app.get("/status")
def status():
    return {"status": "OK", "message": "Server is running"}

if __name__ == "__main__":
    uvicorn.run("server_yolo:app", host="0.0.0.0", port=7007, reload=True)
