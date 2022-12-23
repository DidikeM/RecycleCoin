# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

import objectDetectionService_pb2 as objectDetectionService__pb2


class ObjectDetectorStub(object):
    """Missing associated documentation comment in .proto file."""

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.detectObject = channel.unary_unary(
            "/objectDetectionService.ObjectDetector/detectObject",
            request_serializer=objectDetectionService__pb2.ImageProvided.SerializeToString,
            response_deserializer=objectDetectionService__pb2.Detection.FromString,
        )


class ObjectDetectorServicer(object):
    """Missing associated documentation comment in .proto file."""

    def detectObject(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details("Method not implemented!")
        raise NotImplementedError("Method not implemented!")


def add_ObjectDetectorServicer_to_server(servicer, server):
    rpc_method_handlers = {
        "detectObject": grpc.unary_unary_rpc_method_handler(
            servicer.detectObject,
            request_deserializer=objectDetectionService__pb2.ImageProvided.FromString,
            response_serializer=objectDetectionService__pb2.Detection.SerializeToString,
        ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
        "objectDetectionService.ObjectDetector", rpc_method_handlers
    )
    server.add_generic_rpc_handlers((generic_handler,))


# This class is part of an EXPERIMENTAL API.
class ObjectDetector(object):
    """Missing associated documentation comment in .proto file."""

    @staticmethod
    def detectObject(
        request,
        target,
        options=(),
        channel_credentials=None,
        call_credentials=None,
        insecure=False,
        compression=None,
        wait_for_ready=None,
        timeout=None,
        metadata=None,
    ):
        return grpc.experimental.unary_unary(
            request,
            target,
            "/objectDetectionService.ObjectDetector/detectObject",
            objectDetectionService__pb2.ImageProvided.SerializeToString,
            objectDetectionService__pb2.Detection.FromString,
            options,
            channel_credentials,
            insecure,
            call_credentials,
            compression,
            wait_for_ready,
            timeout,
            metadata,
        )
