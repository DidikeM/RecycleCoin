using Google.Protobuf;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectDetectionService;
using System.Drawing;
using System.Drawing.Imaging;

namespace RecycleCoin.API.Concrete
{
    public static class ObjectDetectService
    {
        public static async Task<Detection?> ObjectDetect(Image image)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:7334");

            var client = new ObjectDetector.ObjectDetectorClient(channel);

            var response = await client.detectObjectAsync(new ImageProvided
            {
                ImageBytes = ImageToByteString(image)
            });

            return response;
        }

        public static ByteString ImageToByteString(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ByteString.CopyFrom(ms.ToArray());
            }
        }
    }
}
