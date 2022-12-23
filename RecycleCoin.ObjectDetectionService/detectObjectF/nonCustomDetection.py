import cv2
import numpy as np
import time
import os
import base64


def runDetection(byteString):

    ROOT_DIR = os.path.dirname(__file__)

    nparr = np.fromstring(byteString, np.uint8)
    img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)

    # Define required params for object detection
    net = cv2.dnn.readNet(
        f"{ROOT_DIR}\\yolov3_custom_final.weights",
        f"{ROOT_DIR}\\yolov3_custom.cfg",
    )
    classes = []
    with open(f"{ROOT_DIR}\\classes.txt", "r") as f:
        classes = f.read().splitlines()

    # Define color and font for bboxes
    font = cv2.FONT_HERSHEY_PLAIN
    colors = np.random.uniform(0, 255, size=(2, 3))


    height, width, _ = img.shape
    blob = cv2.dnn.blobFromImage(
        img, 1 / 255, (416, 416), (0, 0, 0), swapRB=True, crop=False
    )
    net.setInput(blob)
    output_layers_names = net.getUnconnectedOutLayersNames()
    layerOutputs = net.forward(output_layers_names)

    boxes = []
    confidences = []
    class_ids = []

    for output in layerOutputs:
        for detection in output:
            scores = detection[5:]
            class_id = np.argmax(scores)
            confidence = scores[class_id]
            if confidence > 0.6:
                center_x = int(detection[0] * width)
                center_y = int(detection[1] * height)
                w = int(detection[2] * width)
                h = int(detection[3] * height)

                x = int(center_x - w / 2)
                y = int(center_y - h / 2)

                boxes.append([x, y, w, h])
                confidences.append((float(confidence)))
                class_ids.append(class_id)

    indexes = cv2.dnn.NMSBoxes(boxes, confidences, 0.2, 0.4)

    if len(indexes) > 0:
        for i in indexes.flatten():
            x, y, w, h = boxes[i]
            label = str(classes[class_ids[i]])
            confidence = str(round(confidences[i], 2))
            color = colors[i]
            cv2.rectangle(img, (x, y), (x + w, y + h), color, 2)
            objectIndex = i + 1
            cv2.putText(
                img,
                label + " " + confidence,
                (x, y + 20),
                font,
                2,
                (255, 255, 0),
                2,
            )
    else:
        objectIndex = -1

    #cv2.imwrite(f"{ROOT_DIR}\\DetectedPhoto.jpg", img)
    editedImageBytes = cv2.imencode(".jpg", img)[1].tostring()
    return editedImageBytes, objectIndex
