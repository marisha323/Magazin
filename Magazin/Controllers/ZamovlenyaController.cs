using Microsoft.AspNetCore.Mvc;

namespace Magazin.Controllers
{
    public class ZamovlenyaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
