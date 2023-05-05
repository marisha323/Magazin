using Magazin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Magazin.Controllers
{
    public class AddProductController : Controller
    {
        MagazinContext context;
        [BindProperty]
        Product product { get; set; }
        Category category { get; set; }
        Imeg imeg { get; set; }
        public AddProductController(MagazinContext db)
        {
            this.context = db;
        }
        //public async Task<ActionResult> Index(/*[Bind] Product product1*/)
        //{
        //    //context.Products.Add(product1);
        //    //await context.SaveChangesAsync();
        //    //return Redirect("/ConferenceForRegistered/Index");

        //    return View();
        //}

        public IActionResult AddCatedory(string catName)
        {
            context.Categories.Add(new Category() { Name = catName });
            context.SaveChanges();
            ViewBag.Categorya = context.Categories.AsNoTracking().ToList();
            return View("Index");
        }
        public async Task<IActionResult> AddProduct([Bind] Product product1)
        {
            var category = Request.Form["Category"];
            var catId = context?.Categories?.FirstOrDefault(o => o.Name.Equals(category)).Id;
            product1.CategoryId = catId;
            //var files = Request.Form.Files;

            await context.SaveChangesAsync();


            IFormFileCollection files = Request.Form.Files;

            var passrom = $@"{Directory.GetCurrentDirectory()}/wwwroot/Imeg2/{product1.Name.Replace(" ", "-")}";
            Directory.CreateDirectory(passrom);
            product1.PathLong = $"{files[0].FileName}";
            //using (var fs = new FileStream(product1.PathLong, FileMode.Create))
            //{
            //    await files[0].CopyToAsync(fs);
            //}
            //product1.PathLong = product1.PathLong.Split("wwwroot")[1];
            context.Products.Add(product1);
            await context.SaveChangesAsync();

            //product1 = context.Products.Where(o => o.Name == product1.Name).AsNoTracking().FirstOrDefault();
            // context.Imegs.Add(new Imeg() { Pass = files[0].FileName, ProductId = product1.Id });
            // context.AddAsync(product1);

            await context.SaveChangesAsync();

            //for (int i = 1; i < files.Count; i++)
            //{}
            var path = $@"{Directory.GetCurrentDirectory()}/wwwroot/Imeg2/{product1.Name.Replace(" ", "-")}";
            Directory.CreateDirectory(path);
            foreach (var file in files)
            {


                //imeg = new Imeg();
                //imeg.ProductId = context.Products.Where(o => o.Name == product1.Name).FirstOrDefault().Id;

                //imeg.Pass = $"{file.FileName}";
                string FullPath = $"{path}/{file.FileName}";
                using (var fs = new FileStream(FullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
                var imeg = new Imeg();
                imeg.ProductId = product1.Id;
                imeg.Pass = file.FileName; /*imeg.Pass.Split("wwwroot")[1];*/
                await context.AddAsync(imeg);
            }


            await context.SaveChangesAsync();

            return Redirect("/Home/Index");
        }
        public IActionResult Index()
        {
            ViewBag.Categorya = context.Categories.AsNoTracking().ToList();

            return View();
        }
    }
}
