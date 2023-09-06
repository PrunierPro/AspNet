using TPCaisse.Data;
using TPCaisse.Models;

namespace TPCaisse.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Product product)
        {
            var added = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return added.Entity.Id > 0;
        }

        public bool Delete(int id)
        {
            var toDelete = GetById(id);
            if (toDelete == null) return false;
            _dbContext.Products.Remove(toDelete);
            return _dbContext.SaveChanges() > 0;

        }

        public Product? Get(System.Linq.Expressions.Expression<Func<Product, bool>> predicate)
        {
            return _dbContext.Products.FirstOrDefault(predicate);
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public List<Product> GetAll(System.Linq.Expressions.Expression<Func<Product, bool>> predicate)
        {
            return _dbContext.Products.Where(predicate).ToList();
        }

        public Product? GetById(int id)
        {
            return Get(p => p.Id == id);
        }

        public bool Update(Product product)
        {
            var toUpdate = GetById(product.Id);
            if (toUpdate == null) return false;

            if (toUpdate.Name != product.Name) toUpdate.Name = product.Name;
            if (toUpdate.Description != product.Description) toUpdate.Description = product.Description;
            if (toUpdate.Price != product.Price) toUpdate.Price = product.Price;
            if (toUpdate.Quantity != product.Quantity) toUpdate.Quantity = product.Quantity;
            if (toUpdate.Category != product.Category) toUpdate.Category = product.Category;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
