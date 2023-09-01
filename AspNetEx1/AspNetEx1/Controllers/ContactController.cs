using Microsoft.AspNetCore.Mvc;

namespace AspNetEx1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
