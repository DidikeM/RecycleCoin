using Microsoft.AspNetCore.Mvc;
using RecycleCoin.API.Concrete;
using System.Drawing.Imaging;
using System.Drawing;
using System.Dynamic;
using RecycleCoin.Business.Concrete;
using RecycleCoin.WebUI.Models;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;

namespace RecycleCoin.WebUI.Controllers
{
    public class OperatorController : Controller
    {
        IProductService _productService = InstanceFactory.GetInstance<IProductService>();
        IUserService _userService = InstanceFactory.GetInstance<IUserService>();
        IRecycleService _recycleService = InstanceFactory.GetInstance<IRecycleService>();
        IRecycleDetailService _recycleDetailService = InstanceFactory.GetInstance<IRecycleDetailService>();
        ICustomerService _customerService = InstanceFactory.GetInstance<ICustomerService>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IntroduceProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IntroduceProduct(DetectedObject detectedObject, List<RecycleDetailModel> recycleDetailModels)
        {
            if (recycleDetailModels == null)
            {
                recycleDetailModels = new List<RecycleDetailModel>();
            }
            #region Base64 to image
            //byte[] bytes = Convert.FromBase64String(imageString);
            //Image image;
            //using (MemoryStream ms = new MemoryStream(bytes))
            //{
            //    image = Image.FromStream(ms);
            //}
            //Bitmap imm = new Bitmap(image);
            #endregion

            if (detectedObject.ObjectIndex == -1)
            {
                detectedObject = await ObjectDetectService.DetectObjectFromBase64(detectedObject.DetectedImageBase64!);
            }
            else
            {
                var detail = recycleDetailModels.FirstOrDefault(p => p.ProductId == detectedObject.ObjectIndex);
                if (detail != null)
                {
                    detail.ProductQuantity++;
                    detail.SubTotalPrice += detail.ProductPoint;
                }
                else
                {
                    var product = _productService.GetById(detectedObject.ObjectIndex);
                    recycleDetailModels.Add(new RecycleDetailModel
                    {
                        ProductId = detectedObject.ObjectIndex,
                        ProductName = product.Name,
                        ProductPoint = product.Price,
                        ProductQuantity = 1,
                        SubTotalPrice = product.Price
                    });
                }
                //detectedObject = null!;
                detectedObject.ObjectIndex = -1;
            }
            #region image to base64
            //Bitmap img = new Bitmap(response.DetectedImage!);
            //string base64String;
            //using (MemoryStream m = new MemoryStream())
            //{
            //    img.Save(m, ImageFormat.Jpeg);
            //    byte[] imageBytes = m.ToArray();

            //    // Convert byte[] to Base64 String
            //    base64String = Convert.ToBase64String(imageBytes);
            //}
            #endregion


            IntroduceProductModel model = new IntroduceProductModel();
            model.detectedObject = detectedObject;
            model.RecycleDetailModels = recycleDetailModels;

            return View(model);
        }

        #region Image save webcam
        //private static async Task<DetectedObject> StoreInFolder(IFormFile file, string fileName)
        //{
        //    using var image = Image.FromStream(file.OpenReadStream());
        //    var a = await ObjectDetectService.DetectObject(image);
        //    var imm = new Bitmap(a.DetectedImage!);
        //    imm.Save(fileName, ImageFormat.Jpeg);
        //    return new DetectedObject();
        //}

        //private void StoreInDatabase(byte[] imageBytes)
        //{
        //    //Saving captured into database
        //}

        #endregion
        #region old
        //[HttpPost]
        //public async Task<IActionResult> IntroduceProductAsync()
        //{
        //    try
        //    {
        //        var files = HttpContext.Request.Form.Files;
        //        if (files != null)
        //        {
        //            foreach (var file in files)
        //            {
        //                if (file.Length > 0)
        //                {
        //                    var fileName = file.FileName;
        //                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
        //                    var fileExtension = Path.GetExtension(fileName);
        //                    var newFileName = string.Concat(myUniqueFileName, fileExtension);
        //                    var filePath = Path.Combine(_environment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";
        //                    if (!string.IsNullOrEmpty(filePath))
        //                    {
        //                        var a = await StoreInFolder(file, filePath);
        //                    }
        //                    var imageBytes = System.IO.File.ReadAllBytes(filePath);
        //                    if (imageBytes != null)
        //                    {
        //                        StoreInDatabase(imageBytes);
        //                    }
        //                }
        //            }
        //            return Json(true);
        //        }
        //        else
        //        {
        //            return Json(false);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    };
        //}
        #endregion

        [HttpPost]
        public IActionResult SetRecycleToUser(SetRecycleModel setRecycleModel)
        {
            if (setRecycleModel.UserModels == null)
            {
                setRecycleModel.UserModels = new List<UserModel>();
            }

            List<User> users = _userService.GetByRoleId(3);
            foreach (var user in users)
            {
                setRecycleModel.UserModels.Add(new UserModel
                {
                    Email = user.Email,
                    Id = user.Id,
                    Username = user.Username,
                });
            }
            return View(setRecycleModel);
        }

        [HttpPost]
        public IActionResult RecycleConfirmed(int userID, List<RecycleDetailModel> recycleDetailModels)
        {
            Customer customer = _customerService.GetByUserId(userID);
            Recycle recycle = new Recycle
            {
                CustomerId = customer.Id,
                Date = DateTime.Now
            };
            _recycleService.AddRecycle(recycle);
            foreach (var recycleDetailModel in recycleDetailModels)
            {
                _recycleDetailService.AddRecycleDetail(new RecycleDetail
                {
                    ProductId= recycleDetailModel.ProductId,
                    ProductQuantity= recycleDetailModel.ProductQuantity,
                    RecycleId = recycle.Id,
                    SubTotalPrice= recycleDetailModel.SubTotalPrice
                });
                customer.CarbonBalance += recycleDetailModel.SubTotalPrice;
            }
            return View();
        }
    }
}
