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
            if(task.Id > 0)
            {
                _repository.Update(task);
            }
            else _repository.Add(task);

            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            Todo task = _repository.GetById(id);
            task.Done = !task.Done;
            _repository.Update(task);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Todo task = _repository.GetById(id);
            return View("Add", task);
        }
    }
}
