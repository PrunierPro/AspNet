using AspNetEx4.Data;
using AspNetEx4.Models;
using System.Linq.Expressions;

namespace AspNetEx4.Repositories
{
    public class MarmosetRepository : IRepository<Marmoset>
    {
        private ApplicationDbContext _dbContext;

        public MarmosetRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Marmoset entity)
        {
            var added = _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return added.Entity.Id > 0;
        }

        public Marmoset? Get(Expression<Func<Marmoset, bool>> predicate)
        {
            return _dbContext.Marmosets.FirstOrDefault(predicate);
        }

        public Marmoset? GetById(int entityId)
        {
            return _dbContext.Marmosets.FirstOrDefault(m => m.Id == entityId);
        }

        public List<Marmoset> GetAll()
        {
            return _dbContext.Marmosets.ToList();
        }

        public bool Delete(int entityId) 
        {
            var deleted = _dbContext.Remove(GetById(entityId));
            _dbContext.SaveChanges();
            return deleted.Entity.Id > 0;
        }
    }
}
