using Magazin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Magazin.Controllers
{
    public class CartProductController : Controller
    {
        MagazinContext context;
        [BindProperty]
        public User? user { get; set; }

        public CartProductController(MagazinContext db)
        {
            this.context = db;

        }

        public IActionResult Index(int id)
        {
            //ViewBag.Photos = context.Imegs.ToList()
            var prod = context.Products.FirstOrDefault(o=>o.Id==id);
            var imegs = context.Imegs.Where(o => o.ProductId == id).ToList();
            ViewBag.Imegs=imegs;
            return View(prod);
        }
    }
}
