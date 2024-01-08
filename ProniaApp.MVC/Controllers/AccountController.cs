using Microsoft.AspNetCore.Mvc;

namespace ProniaApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
