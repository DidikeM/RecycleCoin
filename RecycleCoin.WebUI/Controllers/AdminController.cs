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
        IContactService _contactService = InstanceFactory.GetInstance<IContactService>();

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

        public IActionResult Question()
        {
            List<Contact> contacts = _contactService.GetAll();

            return View(contacts);
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
