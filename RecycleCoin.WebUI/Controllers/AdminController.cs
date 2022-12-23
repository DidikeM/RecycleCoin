using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;
using RecycleCoin.WebUI.Models;

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
        public IActionResult IntroduceProduct(string name)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = file.FileName;
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                            var fileExtension = Path.GetExtension(fileName);
                            var newFileName = string.Concat(myUniqueFileName, fileExtension);
                            var filePath = Path.Combine(_environment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                StoreInFolder(file, filePath);
                            }
                            var imageBytes = System.IO.File.ReadAllBytes(filePath);
                            if (imageBytes != null)
                            {
                                StoreInDatabase(imageBytes);
                            }
                        }
                    }
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {

                throw;
            };
        }

        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
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
