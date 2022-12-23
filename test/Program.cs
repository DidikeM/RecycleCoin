// See https://aka.ms/new-console-template for more information

using Google.Protobuf;
using RecycleCoin.API.Concrete;
using System.Drawing;
using System.Drawing.Imaging;
using test;

Test test = new Test();

var response = await ObjectDetectService.DetectObject(Image.FromFile("../../../img.jpg"));



var imm = new Bitmap(response.DetectedImage!);
imm.Save("../../../blablaimg.jpg", ImageFormat.Jpeg);
