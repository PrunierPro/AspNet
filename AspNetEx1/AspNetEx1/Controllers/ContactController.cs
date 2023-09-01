using Microsoft.AspNetCore.Mvc;

namespace AspNetEx1.Controllers
{
    public class ContactController : Controller
    {
        public string Show(int? id)
        {
            return $"I am the page for showing a specific contact {(id is not null ? $"| ID : {id}" : "")}";
        }

        public string Add()
        {
            return "I am the page for adding a contact";
        }

        public string Index()
        {
            return "I am the page for listing all contacts";
        }
    }
}
