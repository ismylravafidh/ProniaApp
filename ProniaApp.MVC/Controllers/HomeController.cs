using Microsoft.AspNetCore.Mvc;

namespace ProniaApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
