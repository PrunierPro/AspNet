using AspNetEx1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetEx1.Controllers
{
    public class ContactController : Controller
    {

        List<Contact> fakeContacts = new List<Contact>(new Contact[] { new Contact() { Id = 0, FName = "Joe", LName = "Doe" }, new Contact() { Id = 1, FName = "Jane", LName = "Doe" } });

        public IActionResult Show(int id = 1)
        {
            Contact contact = fakeContacts[id];
            return View(contact);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Index()
        {

            ViewBag.Contacts = fakeContacts;
            return View();
        }
    }
}
