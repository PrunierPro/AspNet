using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPCaisse.Models;
using TPCaisse.Repositories;

namespace TPCaisse.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _repository;

        public ProductController(ProductRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Products = _repository.GetAll();
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(_repository.GetById(id));
        }

        public IActionResult AddProduct()
        {
            return View("ProductForm");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View("ProductForm", _repository.GetById(id));
        }

        public IActionResult Submit(Product product)
        {
            if(product.Id > 0)
            {
                _repository.Update(product);
            } else
            {
                _repository.Add(product);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}