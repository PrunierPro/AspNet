using Microsoft.EntityFrameworkCore;
using TPCaisse.Data;
using TPCaisse.Models;

namespace TPCaisse.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Category category)
        {
            var added = _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return added.Entity.Id > 0;
        }

        public bool Delete(int id)
        {
            var toDelete = GetById(id);
            if (toDelete == null) return false;
            _dbContext.Categories.Remove(toDelete);
            return _dbContext.SaveChanges() > 0;
        }

        public Category? Get(System.Linq.Expressions.Expression<Func<Category, bool>> predicate)
        {
            return _dbContext.Categories.Include(c => c.Products).FirstOrDefault(predicate);
        }

        public List<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public List<Category> GetAll(System.Linq.Expressions.Expression<Func<Category, bool>> predicate)
        {
            return _dbContext.Categories.Where(predicate).ToList();
        }

        public Category? GetById(int id)
        {
            return Get(c => c.Id == id);
        }

        public bool Update(Category category)
        {
            var toUpdate = GetById(category.Id);
            if (toUpdate == null) return false;

            if (toUpdate.Name != category.Name) toUpdate.Name = category.Name;
            if (!toUpdate.Products.Equals(category.Products)) toUpdate.Products = category.Products;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
