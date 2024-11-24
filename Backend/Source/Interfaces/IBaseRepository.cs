using Source.Entities;
using System.Linq.Expressions;

namespace Source.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Commit();
        Task CommitAsync();
        void Create(TEntity entity);
        void Create(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        Task<IList<TEntity>> GetAll();
        Task<IList<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetQueryable();
        void Update(TEntity entity);
        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
