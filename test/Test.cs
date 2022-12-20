//using RecycleCoin.API.Concrete;
using coineservice;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;
using System.IO;
using System.Drawing;
using Google.Protobuf;
using RecycleCoin.API.Concrete;
using System.Drawing.Imaging;

namespace test
{
    public class Test
    {
        IUserService userService = InstanceFactory.GetInstance<IUserService>();
        IRoleService roleService = InstanceFactory.GetInstance<IRoleService>();
        ITopicService topicSevice = InstanceFactory.GetInstance<ITopicService>();
        IReplyService replyService = InstanceFactory.GetInstance<IReplyService>();

        //public static async Task<Detection?> ObjectDetect(Image image)
        //{
        //    ByteString imageBytes = ByteString.CopyFrom(ImageToByteArray(image));


        //    var channel = GrpcChannel.ForAddress("http://localhost:7334");

        //    var client = new ObjectDetector.ObjectDetectorClient(channel);

        //    var response = await client.detectObjectAsync(new ImageProvided
        //    { 
        //    ImageBytes = imageBytes
        //    });

        //    return response;
        //}

        //public static byte[] ImageToByteArray(Image image)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        image.Save(ms, image.RawFormat);
        //        return ms.ToArray();
        //    }
        //}


        public Test()
        {
            var response = ObjectDetectService.ObjectDetect(Image.FromFile("../../../img.jpg"));



            #region resim bilmemn

            //var a = new Bitmap(Image.FromFile("../../../img.jpg"));
            //ByteString imgbyte = RecycleCoin.API.Concrete.ObjectDetectService.ImageToByteString(a);

            //byte[] imageData = imgbyte.ToByteArray();
            //Image image;
            //// Create a stream from the byte array
            //using (MemoryStream ms = new MemoryStream(imageData))
            //{
            //    // Create an image from the stream
            //    image = Image.FromStream(ms);
            //}
            //var imm = new Bitmap(image);
            //imm.Save("../../../blablaimg.jpg", ImageFormat.Jpeg);

            #endregion




            //Image image = Image.FromFile("image.jpg");
            //byte[] imageBytes = ImageToByteArray(image);



            //var x = new CoinTransferSoapPortClient(CoinTransferSoapPortClient.EndpointConfiguration.CoinTransferServiceSoapPort);
            //var y = x.CoinTransferAsync("RBWWdhuJeSetUaXvUy267jNo3xY5JDbjdC", "3");
            //y.Wait();

            //var result = y.Result;
            //Console.WriteLine(result.result[0]);
        }
    }
}
