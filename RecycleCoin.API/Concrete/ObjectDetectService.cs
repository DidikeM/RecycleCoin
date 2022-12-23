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
        public static async Task<DetectedObject> DetectObject(Image image)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:7334");

            var client = new ObjectDetector.ObjectDetectorClient(channel);

            var response = await client.detectObjectAsync(new ImageProvided
            {
                ImageBytes = ImageToByteString(image)
            });
            var detectedImage = ByteStringToImage(response.ImageEditedBytes);
            return new DetectedObject
            {
                DetectedImage= detectedImage,
                ObjectIndex = response.ObjectIndex,
            };
        }

        public static async Task<DetectedObject> DetectObjectFromBase64(string base64ImageString)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:7334");

            var client = new ObjectDetector.ObjectDetectorClient(channel);

            var response = await client.detectObjectAsync(new ImageProvided
            {
                ImageBytes = ImageToByteString(Base64ToImage(base64ImageString))
            });
            var detectedImage = ByteStringToImage(response.ImageEditedBytes);
            return new DetectedObject
            {
                DetectedImage = detectedImage,
                ObjectIndex = response.ObjectIndex,
                DetectedImageBase64 = ImageToBase64(detectedImage)
            };
        }

        private static Image Base64ToImage(string imageString)
        {
            byte[] bytes = Convert.FromBase64String(imageString);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            return new Bitmap(image);
        }

        private static string ImageToBase64(Image image)
        {
            Bitmap img = new Bitmap(image);
            string base64String;
            using (MemoryStream m = new MemoryStream())
            {
                img.Save(m, ImageFormat.Jpeg);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                base64String = Convert.ToBase64String(imageBytes);
            }
            return base64String;
        }

        private static ByteString ImageToByteString(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ByteString.CopyFrom(ms.ToArray());
            }
        }

        private static Image ByteStringToImage(ByteString bytes)
        {
            Image image;
            // Create a stream from the byte array
            using (MemoryStream ms = new MemoryStream(bytes.ToByteArray()))
            {
                // Create an image from the stream
                image = Image.FromStream(ms);
            }
            return image;
        }

        //public static async Task<DetectedObject> GetImageAsync(Image img)
        //{
        //    var response = await ObjectDetect(img);

        //    byte[] imageData = response!.ImageEditedBytes.ToByteArray();
        //    Image image;
        //    // Create a stream from the byte array
        //    using (MemoryStream ms = new MemoryStream(imageData))
        //    {
        //        // Create an image from the stream
        //        image = Image.FromStream(ms);
        //    }
        //    var imm = new Bitmap(image);

        //    return new DetectedObject
        //    {
        //        DetectedImage= imm,
        //        ObjectIndex = response.ObjectIndex
        //    };
        //}
    }
}
