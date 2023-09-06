using System.Linq.Expressions;

namespace TPCaisse.Repositories
{
    public interface IRepository<TEntity>
    {
        bool Add(TEntity entity);
        bool Delete(int id);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        bool Update(TEntity entity);
    }
}
