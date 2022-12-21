// See https://aka.ms/new-console-template for more information

using Google.Protobuf;
using RecycleCoin.API.Concrete;
using System.Drawing;
using System.Drawing.Imaging;
using test;

Test test = new Test();

var response = await ObjectDetectService.ObjectDetect(Image.FromFile("../../../img.jpg"));


byte[] imageData = response.ImageEditedBytes.ToByteArray();
Image image;
// Create a stream from the byte array
using (MemoryStream ms = new MemoryStream(imageData))
{
    // Create an image from the stream
    image = Image.FromStream(ms);
}
var imm = new Bitmap(image);
imm.Save("../../../blablaimg.jpg", ImageFormat.Jpeg);
