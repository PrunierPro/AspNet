using AspNetEx4.Data;
using AspNetEx4.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetEx4.Controllers
{
    public class MarmosetController : Controller
    {
        private FakeMarmosetDb _marmosetDb;

        public MarmosetController(FakeMarmosetDb marmosetDb)
        {
            _marmosetDb = marmosetDb;
        }

        public IActionResult Index()
        {
            ViewBag.Marmosets = _marmosetDb.GetAll();
            return View();
        }

        public IActionResult Details(int id)
        {
            Marmoset m = _marmosetDb.GetById(id);
            return View(m);
        }

        public void CreateRandom()
        {
            Random rand = new Random();
            int age = rand.Next(1, 10);
            string name = new string(Enumerable.Repeat("ABCDEFGHJIKLMNOPQRSTUVWXYZ", rand.Next(1, 10)).Select(s => s[rand.Next(s.Length)]).ToArray());
            int id = _marmosetDb.GetAll().Count;
            _marmosetDb.Add(new Marmoset { Id = id, Name = name, Age = age });
            Response.Redirect("/Marmoset");
        }
    }
}
