using Microsoft.AspNetCore.Mvc;
using TPTodo.Models;
using TPTodo.Repositories;

namespace TPTodo.Controllers
{
    public class TodoController : Controller
    {
        private TodoRepository _repository;
        public TodoController(TodoRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Tasks = _repository.GetAll();
            return View();
        }

        public IActionResult AddTask()
        {
            return View("Add");
        }

        public IActionResult Submit(Todo task)
        {
            _repository.Add(task);

            return RedirectToAction("Index");
        }
    }
}
