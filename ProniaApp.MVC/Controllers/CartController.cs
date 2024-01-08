using Microsoft.AspNetCore.Mvc;

namespace ProniaApp.MVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
