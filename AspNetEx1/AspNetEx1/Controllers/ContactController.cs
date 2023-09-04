using AspNetEx1.Data;
using AspNetEx1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Xml.Linq;

namespace AspNetEx1.Controllers
{
    public class ContactController : Controller
    {
        private FakeContactDb _contacts;

        public ContactController(FakeContactDb contacts)
        {
            _contacts = contacts;
        }

        public IActionResult Show(int id = 1)
        {
            Contact contact = _contacts.Get(id);
            return View(contact);
        }

        public IActionResult Add([FromForm] string? fname, [FromForm] string? lname, [FromForm] string? email, [FromForm] string? phone)
        {
            if(fname is not null && lname is not null)
            {
                ViewData["RouteId"] = _contacts.GetAll().Count;
                _contacts.Add(new Contact() { Id = _contacts.GetAll().Count, FName = fname, LName = lname, Email = email, Phone = phone });
                ViewData["Status"] = 201;
            }
            return View();
        }

        public IActionResult Index()
        {

            ViewBag.Contacts = _contacts.GetAll();
            return View();
        }
    }
}
