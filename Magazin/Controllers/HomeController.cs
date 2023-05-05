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
        //public IActionResult Search(string search)
        //{
        //    if (string.IsNullOrEmpty(search))
        //    {
        //        if (seekInfos[listBox1.SelectedIndex].Type == "Пісня")
        //        {
        //            //string pass3 = seekInfos[listBox1.SelectedIndex].FoundValue;
        //            //string pass22 = db.Musics.Where(o => o.PhotoMusic == pass3).First().Pass;






        //            //MemoryStream mstream = new MemoryStream(db.Musics.Select(o => o.PhotoMusic).First());
        //            //ImageSource s = BitmapFrame.Create(mstream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        //            //pictureBox1.Image = s;
        //            //string pas = "C:/Users/User/Desktop/vep36.jpg";
        //            //pictureBox1.Image = Image.FromFile($"{pass3}");



        //            string pass1 = seekInfos[listBox1.SelectedIndex].FoundValue;
        //            string pass = db.Musics.Where(o => o.NameMusic == pass1).First().Pass;
        //            // MessageBox.Show(pass);
        //            wplayer.URL = $"{pass}";
        //            wplayer.settings.volume = 10;

        //            label2.Text = trackBar1.Value.ToString();
        //            wplayer.controls.play();



        //        }
        //        if (seekInfos[listBox1.SelectedIndex].Type == "Виконавець")
        //        {
        //            var mus = seekInfos[listBox1.SelectedIndex].FoundValue;



        //            var music = db.Musics.Join(db.Publications, o => o.PublicationsId, p => p.Id, (o, p) => new { o.NameMusic, p.NamePublications }).Where(o => o.NamePublications == mus).ToList();



        //            //var dbset = from s in db.Musics
        //            //            join m in db.Publications on s.PublicationsId equals m.Id
        //            //            select new { No = s.Id, Music = s.NameMusic, Publications = m.NamePublications };



        //            seekInfos.Clear();
        //            foreach (var item in music)
        //            {

        //                seekInfos.Add(new SeekInfo { FoundValue = item.NameMusic, Type = "Пісня" });




        //            }




        //        }
        //        if (seekInfos[listBox1.SelectedIndex].Type == "Група")
        //        {
        //            var mus2 = seekInfos[listBox1.SelectedIndex].FoundValue;



        //            var music2 = db.Publications.Join(db.Groups, o => o.GroupId, p => p.Id, (o, p) => new { o.NamePublications, p.NameGroup }).Where(o => o.NameGroup == mus2).ToList();
        //            seekInfos.Clear();
        //            foreach (var item in music2)
        //            {
        //                seekInfos.Add(new SeekInfo { FoundValue = item.NamePublications, Type = "Виконавець" });



        //            }
        //        }

        //    }
        //}
        //    return View();
        //}


       
        public IActionResult Index()
        {
            //Role role1 = new Role() { Name = "admin" };
            //Role role2 = new Role() { Name = "director" };
            //Role role3 = new Role() { Name = "meneger" };
            //Role role4 = new Role() { Name = "user" };
            //user = new User() { Name = "Ivan", Email = "ivan123@gmail.com", Phone = "0976665544", Password = "1234" };
            //context.Roles.Add(role1);
            //context.Roles.Add(role2);
            //context.Roles.Add(role3);
            //context.Roles.Add(role4);
            //context.SaveChanges();
            //context.Users.Add(user);
            //context.SaveChanges();
            //ViewBag.Photos = context.Imegs.ToList();
            imegs = context.Imegs.ToList();
            ViewBag.Categorya = context.Categories.AsNoTracking().ToList();
            return View(context.Products.ToList());
        }

        public IActionResult Privacy()
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