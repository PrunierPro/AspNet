using AspNetEx4.Data;
using AspNetEx4.Models;
using AspNetEx4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetEx4.Controllers
{
    public class MarmosetController : Controller
    {
        //EX 4
        //private FakeMarmosetDb _marmosetDb;

        //EX 5
        //private ApplicationDbContext _marmosetDbContext;

        private MarmosetRepository _repository;

        public MarmosetController(MarmosetRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.Marmosets = _repository.GetAll();
            return View();
        }

        public IActionResult Details(int id)
        {
            Marmoset m = _repository.GetById(id);
            return View(m);
        }

        public void CreateRandom()
        {
            Random rand = new Random();
            int age = rand.Next(1, 10);
            string name = new string(Enumerable.Repeat("ABCDEFGHJIKLMNOPQRSTUVWXYZ", rand.Next(1, 10)).Select(s => s[rand.Next(s.Length)]).ToArray());
            _repository.Add(new Marmoset { Name = name, Age = age });
            Response.Redirect("/Marmoset");
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            Response.Redirect("/Marmoset");
        }
    }
}
