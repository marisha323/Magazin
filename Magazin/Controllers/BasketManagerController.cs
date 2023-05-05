using Microsoft.AspNetCore.Mvc;

namespace Magazin.Controllers
{
    public class BasketManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
