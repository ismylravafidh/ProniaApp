using Microsoft.AspNetCore.Mvc;

namespace ProniaApp.MVC.Areas.Manage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
