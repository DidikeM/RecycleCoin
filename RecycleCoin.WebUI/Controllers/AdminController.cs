using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;
using RecycleCoin.WebUI.Models;
using System.Drawing;
using System.Drawing.Imaging;
using RecycleCoin.API.Concrete;
using System.Buffers.Text;
using System.Dynamic;
using Google.Protobuf;

namespace RecycleCoin.WebUI.Controllers
{
    [Authorize(policy: "AdminClaimPolicy")]
    public class AdminController : Controller
    {
        IUserService _userService = InstanceFactory.GetInstance<IUserService>();
        IRoleService _roleService = InstanceFactory.GetInstance<IRoleService>();

        private readonly IWebHostEnvironment _environment;

        public AdminController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetOperator()
        {
            dynamic model = new
            {
                users = GetUsers(),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SetOperator(int userId, int roleID)
        {
            _userService.UpdateRole(userId, roleID);
            dynamic model = new
            {
                users = GetUsers(),
            };
            return View(model);
        }

        public IActionResult UserSettings()
        {
            return View();
        }

        public IActionResult IntroduceProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IntroduceProduct(string imageString)
        {

            //byte[] bytes = Convert.FromBase64String(imageString);
            //Image image;
            //using (MemoryStream ms = new MemoryStream(bytes))
            //{
            //    image = Image.FromStream(ms);
            //}
            //Bitmap imm = new Bitmap(image);

            var response = await ObjectDetectService.DetectObjectFromBase64(imageString);

            //Bitmap img = new Bitmap(response.DetectedImage!);
            //string base64String;
            //using (MemoryStream m = new MemoryStream())
            //{
            //    img.Save(m, ImageFormat.Jpeg);
            //    byte[] imageBytes = m.ToArray();

            //    // Convert byte[] to Base64 String
            //    base64String = Convert.ToBase64String(imageBytes);
            //}

            dynamic model = new ExpandoObject();
            model.Image = response.DetectedImageBase64;

            return View(model);
        }



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

        private static async Task<DetectedObject> StoreInFolder(IFormFile file, string fileName)
        {
            using var image = Image.FromStream(file.OpenReadStream());
            var a = await ObjectDetectService.DetectObject(image);
            var imm = new Bitmap(a.DetectedImage!);
            imm.Save(fileName, ImageFormat.Jpeg);
            return new DetectedObject();
        }

        private void StoreInDatabase(byte[] imageBytes)
        {
            //Saving captured into database
        }

        private List<UserModel> GetUsers()
        {
            List<UserModel> userModels = new List<UserModel>();
            List<User> users = _userService.GetAll();
            List<Role> roles = _roleService.GetAll();
            foreach (var user in users)
            {
                userModels.Add(new UserModel
                {
                    Email = user.Email,
                    Id = user.Id,
                    Role = roles.FirstOrDefault(p => p.Id == user.RoleId)!.Name,
                    Username = user.Username,
                });
            }
            return userModels;
        }

    }
}
