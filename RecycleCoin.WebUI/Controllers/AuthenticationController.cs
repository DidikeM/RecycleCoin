using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Business.ValidationRules;
using RecycleCoin.Entities.Concrete.EntityFramework;
using RecycleCoin.WebUI.Models;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;

namespace RecycleCoin.WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        IUserService _userSevice = InstanceFactory.GetInstance<IUserService>();

        [AllowAnonymous]
        public IActionResult Login()
        {
            //ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal; claimsten veri alma fghjsdjkfhsdjk
            //if (null != principal)
            //{
            //    foreach (Claim claim in principal.Claims)
            //    {
            //        var asd = claim.Value;
            //    }
            //}
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            User user = new User
            {
                Email = userModel.Email,
                Password = userModel.Password
            };

            LoginValidator wv = new LoginValidator();
            ValidationResult results = wv.Validate(user);


            if (results.IsValid)
            {
                user = _userSevice.GetByEmailAndPassword(userModel.Email, userModel.Password);

                var claims = new List<Claim>
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                //string returnUrl = HttpContext.Request.Query["returnUrl"];

                //if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                //{
                //    return Redirect(returnUrl);
                //}
                //else
                //{
                //    return RedirectToAction("Index", "Home");
                //}

                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(UserModel userModel)
        {
            User user = new User
            {
                Username = userModel.Username,
                Email = userModel.Email,
                Password = userModel.Password
            };

            LoginValidator wv = new LoginValidator();
            ValidationResult results = wv.Validate(user);

            if (results.IsValid)
            {
                _userSevice.AddUser(new User
                {
                    Email = userModel.Email,
                    RoleId = 3,
                    Password = userModel.Password,
                    Username = userModel.Username
                });
                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgotPassword(string email)
        {
            var user = _userSevice.GetByEmail(email);

            if (user != null)
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Credentials = new NetworkCredential("recyclecointeams@gmail.com", "iignxktfiszbfqva");
                client.Port = 587;
                //client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network; 
                MailMessage mail = new MailMessage();
                mail.To.Add(user.Email);
                mail.From = new MailAddress("recyclecointeams@gmail.com");
                mail.Subject = "Forgot Password";
                mail.IsBodyHtml = true;
                mail.Body += "<b>Hello</b>," + user.Username + "<br/>" + "Your Recycle Coin account password :" + user.Password;

                try
                {
                    client.Send(mail);
                    return RedirectToAction("Login", "Authentication");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                ViewBag.message = false;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
