using Microsoft.AspNetCore.Mvc;

namespace Magazin.Controllers
{
    public class BasketHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
