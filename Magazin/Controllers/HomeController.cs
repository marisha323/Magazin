using Magazin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Magazin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        MagazinContext context;
        [BindProperty]
        public User? user { get; set; }
        public List<Imeg> imegs { get; set; } = new();
        public List<Product> products { get; set; } = new();
        public HomeController(MagazinContext db)
        {
            this.context = db;

        }
       
       
        public IActionResult Index()
        {
            imegs = context.Imegs.ToList();
            ViewBag.Categorya = context.Categories.AsNoTracking().ToList();
         
            return View(context.Products.ToList());
        }
        public ActionResult SortCategory(int? categoryId)
        {
            var products=context.Products.ToList();
            if (categoryId != null)
            {
                products = products.Where(o => o.CategoryId == categoryId).ToList();
            }
            ViewBag.Categorya = context.Categories.ToList();
            return View("Index", products);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult PowerBi()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Categori()
        {
           
            return View();
        }
    }
}