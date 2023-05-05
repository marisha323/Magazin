using Magazin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Magazin.Controllers
{
	public class RegistrationController : Controller
	{

        MagazinContext context;
        
       

        public RegistrationController(MagazinContext db)
        {
            this.context = db;

        }
        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login(string email, string password)
		{
            User user = context.Users.Where(o => o.Email == email && o.Password == password).AsNoTracking().FirstOrDefault();
            if (user != null)
            {
                

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(6);
                options.IsEssential = true;
                options.Path = "/";

                string str = JsonSerializer.Serialize(user);

                HttpContext.Response.Cookies.Append("UserLoggedIn", str, options);



                return Redirect("/Home/Index");

            }
            else
            {
                return Redirect("Index");
            }
        }

        public IActionResult Regist([Bind] User user)
        {


           
            user.RoleId = 2;
            context.Users.Add(user);

            context.SaveChanges();

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(6);
            options.IsEssential = true;
            options.Path = "/";

            string str = JsonSerializer.Serialize(user);

            HttpContext.Response.Cookies.Append("UserLoggedIn", str, options);

            return Redirect("/Home/Index");
        }

        public IActionResult Logout()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now;
            options.IsEssential = true;
            options.Path = "/";

            HttpContext.Response.Cookies.Append("UserLoggedIn", "", options);

            return Redirect("Index");
        }

    }
}
