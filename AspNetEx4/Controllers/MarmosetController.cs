using AspNetEx4.Data;
using AspNetEx4.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetEx4.Controllers
{
    public class MarmosetController : Controller
    {
        //EX 4
        //private FakeMarmosetDb _marmosetDb;

        //EX 5
        private ApplicationDbContext _marmosetDbContext;

        public MarmosetController(ApplicationDbContext marmosetDbContext)
        {
            _marmosetDbContext = marmosetDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.Marmosets = _marmosetDbContext.Marmosets.ToList();
            return View();
        }

        public IActionResult Details(int id)
        {
            Marmoset m = _marmosetDbContext.Marmosets.Find(id);
            return View(m);
        }

        public void CreateRandom()
        {
            Random rand = new Random();
            int age = rand.Next(1, 10);
            string name = new string(Enumerable.Repeat("ABCDEFGHJIKLMNOPQRSTUVWXYZ", rand.Next(1, 10)).Select(s => s[rand.Next(s.Length)]).ToArray());
            //int id = _marmosetDbContext.Marmosets.ToList().Count;
            _marmosetDbContext.Marmosets.Add(new Marmoset { Name = name, Age = age });
            _marmosetDbContext.SaveChanges();
            Response.Redirect("/Marmoset");
        }
    }
}
