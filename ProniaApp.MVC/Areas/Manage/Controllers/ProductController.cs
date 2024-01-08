using Microsoft.AspNetCore.Mvc;

namespace ProniaApp.MVC.Areas.Manage.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
