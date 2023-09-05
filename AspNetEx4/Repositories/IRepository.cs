using System.Linq.Expressions;

namespace AspNetEx4.Repositories
{
    public interface IRepository<TEntity>
    {
        bool Add(TEntity entity);

        TEntity? GetById(int entityId);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> GetAll();

        bool Delete(int entityId);
    }
}
