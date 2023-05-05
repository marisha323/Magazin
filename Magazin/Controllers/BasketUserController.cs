using Magazin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Magazin.Controllers
{

    public class BasketUserController : Controller
    {

        MagazinContext context;
        [BindProperty]
        public User? user { get; set; }
        public Product products { get; set; }

        public BasketUserController(MagazinContext db)
        {
            this.context = db;

        }
        public IActionResult ToCart()
        {
            Dictionary<Product, string> pairs = new Dictionary<Product, string>();
            //List<Product> products = new List<Product>();        
            ViewBag.Products = context.Products.ToList();
            ViewBag.Photos = context.Imegs.ToList();
            ViewBag.Products = products;
            //ViewBag.User = user;             //Total Price
            double subPrice = 0;             //ViewBag.Count = products.Count(); 
            foreach (var item in pairs)
            {
                Product prod = item.Key;
                ViewData["Category"] = context.Categories.Find(prod.CategoryId).Name;
                subPrice += item.Key.Price;
            }
            ViewBag.SubPrice = subPrice;
           
            return View(pairs);
        }
        public async Task<IActionResult> Remove(int id)
        {
            string prodcart = HttpContext.Request.Cookies["cart"] ?? "";
            List<Product> cartProducts = JsonSerializer.Deserialize<List<Product>>(prodcart);

            // Отримання ідентифікатора продукту, який потрібно видалити з корзини
            int productIdToRemove = id;

            // Пошук продукту за його ідентифікатором та видалення з масиву
            Product productToRemove = cartProducts.FirstOrDefault(p => p.Id == productIdToRemove);
            if (productToRemove != null)
            {
                cartProducts.Remove(productToRemove);

                // Оновлення куки зі списком продуктів без видаленого продукту
                string updatedCart = JsonSerializer.Serialize(cartProducts);
                HttpContext.Response.Cookies.Append("cart", updatedCart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
           
            string prodcart = HttpContext.Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(prodcart))
            {
                var products = JsonSerializer.Deserialize<List<Product>>(prodcart);
                var productsInDb = new List<Product>();
                foreach (var product in products)
                {
                    int productId = product.Id;
                    int productAmount =1;

                    // Перевірка наявності продукту у базі даних
                    var productInDb = context.Products.FirstOrDefault(o => o.Id == productId);
                    if (productInDb != null)
                    {
                        productsInDb.Add(productInDb);

                        // Передача даних про продукт через ViewBag
                        ViewBag.ProductId = productInDb.Id;
                        ViewBag.ProdName = productInDb.Name;
                        ViewBag.ProdPrice = productInDb.Price;
                        ViewBag.ProdPathLong = productInDb.PathLong;
                        ViewBag.AmountProd = productAmount;
                        ViewBag.AmountProdMax = productInDb.Number;

                    }
                }

                // Передача списку продуктів в ViewBag
                ViewBag.Products = productsInDb;
            }
            return View();
        }
    }
}
