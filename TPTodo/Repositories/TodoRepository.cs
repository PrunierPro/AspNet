using System.Linq.Expressions;
using TPTodo.Data;
using TPTodo.Models;

namespace TPTodo.Repositories
{
    public class TodoRepository
    {
        private ApplicationDbContext _dbContext;
        public TodoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(Todo task)
        {
            var added = _dbContext.Add(task);
            _dbContext.SaveChanges();
            return added.Entity.Id > 0;
        }

        public bool Delete(int id)
        {
            var deleted = _dbContext.Remove(GetById(id));
            _dbContext.SaveChanges();
            return deleted.Entity.Id > 0;
        }

        public Todo? Get(Expression<Func<Todo, bool>> predicate)
        {
            return _dbContext.TodoList.FirstOrDefault(predicate);
        }

        public List<Todo> GetAll()
        {
            return _dbContext.TodoList.ToList();
        }

        public List<Todo> GetAll(Expression<Func<Todo, bool>> predicate)
        {
            return _dbContext.TodoList.Where(predicate).ToList();
        }

        public Todo? GetById(int id)
        {
            return Get(t => t.Id == id);
        }

        public bool Update(Todo task)
        {
            var taskFromDb = GetById(task.Id);

            if(taskFromDb == null)
            {
                return false;
            }

            if (taskFromDb.Title != task.Title) taskFromDb.Title = task.Title;
            if (taskFromDb.Description != task.Description) taskFromDb.Description = task.Description;
            if (taskFromDb.Done != task.Done) taskFromDb.Done = task.Done;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
