using AspNetEx1.Data;
using AspNetEx1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Xml.Linq;

namespace AspNetEx1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Show(int id = 1)
        {
            Contact contact = FakeContactDb.Get(id);
            return View(contact);
        }

        public IActionResult Add([FromForm] string? fname, [FromForm] string? lname, [FromForm] string? email, [FromForm] string? phone)
        {
            if(fname is not null && lname is not null)
            {
                FakeContactDb.Add(new Contact() { Id = FakeContactDb.Count, FName = fname, LName = lname, Email = email, Phone = phone });
                ViewData["Status"] = 201;
                ViewData["RouteId"] = FakeContactDb.Count-1;
            }
            return View();
        }

        public IActionResult Index()
        {

            ViewBag.Contacts = FakeContactDb.Contacts;
            return View();
        }
    }
}
