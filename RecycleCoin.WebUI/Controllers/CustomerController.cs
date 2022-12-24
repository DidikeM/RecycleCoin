using Microsoft.AspNetCore.Mvc;

namespace RecycleCoin.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult WithDraw()
        {
            return View();
        }
    }
}
