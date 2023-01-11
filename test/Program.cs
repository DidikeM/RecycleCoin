// See https://aka.ms/new-console-template for more information

using RecycleCoin.API.Concrete;
Thread.Sleep(3000);

string question = "How to become an software engineer";
string userApi = "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";
var response = await AutoReplyServices.ReplyQuestion(question, userApi);
Console.WriteLine(response);
//var response = await ObjectDetectService.DetectObject(Image.FromFile("../../../img.jpg"));

//var x = await CoinTransferService.CoinTransferToAdress("RBWWdhuJeSetUaXvUy267jNo3xY5JDbjdC", 3);

//var imm = new Bitmap(response.DetectedImage!);
//imm.Save("../../../blablaimg.jpg", ImageFormat.Jpeg);
