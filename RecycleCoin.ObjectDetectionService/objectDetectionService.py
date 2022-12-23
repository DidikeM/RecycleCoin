import grpc
import objectDetectionService_pb2
import objectDetectionService_pb2_grpc

import os
import sys
from concurrent import futures

ROOT_DIR = os.path.dirname(__file__)
sys.path.insert(0, f"{ROOT_DIR}\\detectObjectF")
from nonCustomDetection import *


class ObjectDetectionServicer(objectDetectionService_pb2_grpc.ObjectDetector):
    def detectObject(self, request, context):
        imageEditedBytes, objectIndex = runDetection(request.imageBytes)
        return objectDetectionService_pb2.Detection(
            imageEditedBytes=imageEditedBytes, objectIndex=objectIndex
        )


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    objectDetectionService_pb2_grpc.add_ObjectDetectorServicer_to_server(
        ObjectDetectionServicer(), server
    )
    server.add_insecure_port("localhost:7334")
    print("Server Started http://localhost:7334")
    server.start()
    server.wait_for_termination()


if __name__ == "__main__":
    serve()
