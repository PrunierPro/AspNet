using AspNetEx1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetEx1.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Show()
        {
            Contact contact = new Contact()
            {
                Id = 1,
                FName = "John",
                LName = "Doe"
            };
            return View(contact);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Index()
        {
            Contact contact1 = new Contact()
            {
                Id = 1,
                FName = "John",
                LName = "Doe"
            };           
            Contact contact2 = new Contact()
            {
                Id = 2,
                FName = "Jane",
                LName = "Doe"
            };
            List<Contact> contacts = new List<Contact>(new Contact[] {contact1, contact2 });
            ViewBag.Contacts = contacts;
            return View();
        }
    }
}
