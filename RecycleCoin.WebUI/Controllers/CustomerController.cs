using Microsoft.AspNetCore.Mvc;

namespace RecycleCoin.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WithDraw()
        {
            return View();
        }
    }
}
