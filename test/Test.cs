using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using System.Drawing;
using RecycleCoin.API.Concrete;


namespace test
{
    public class Test
    {
        IUserService userService = InstanceFactory.GetInstance<IUserService>();
        IRoleService roleService = InstanceFactory.GetInstance<IRoleService>();
        ITopicService topicSevice = InstanceFactory.GetInstance<ITopicService>();
        IProductService productService= InstanceFactory.GetInstance<IProductService>();

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

            

            #region resim bilmemn
            //var response = ObjectDetectService.ObjectDetect(Image.FromFile("../../../img.jpg"));
            //var asd = new ObjectDetectService();
            //var c = asd.ObjectDetect(Image.FromFile("../../../img.jpg"));
            //c.Wait();
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

            //Image image = Image.FromFile("image.jpg");
            //byte[] imageBytes = ImageToByteArray(image);



            //var x = new CoinTransferSoapPortClient(CoinTransferSoapPortClient.EndpointConfiguration.CoinTransferServiceSoapPort);
            //var y = x.CoinTransferAsync("RBWWdhuJeSetUaXvUy267jNo3xY5JDbjdC", "3");
            //y.Wait();

            //var result = y.Result;
            //Console.WriteLine(result.result[0]);
            #endregion



        }
    }
}
