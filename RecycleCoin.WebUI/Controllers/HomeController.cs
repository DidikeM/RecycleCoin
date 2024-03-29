﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;
using RecycleCoin.WebUI.Models;
using System.Diagnostics;

namespace RecycleCoin.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IContactService contactService = InstanceFactory.GetInstance<IContactService>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        //[Authorize(policy: "AdminClaimPolicy")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Contact(Contact contact)
        {
            contactService.Add(contact);
            return View();
        }

        //public IActionResult Forum()
        //{
        //    return View();
        //}

        //public IActionResult Login()
        //{
        //    return View();
        //}

        //public IActionResult Register()
        //{
        //    return View();
        //}

        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}