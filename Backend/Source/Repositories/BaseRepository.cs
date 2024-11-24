using Microsoft.EntityFrameworkCore;
using Source.Entities;
using Source.Interfaces;
using System.Linq.Expressions;

namespace Source.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        protected IQueryable<TEntity> Query { get; private set; }

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
            Query = _dbSet.AsQueryable();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Create(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await Query.ToListAsync();
        }

        public async Task<IList<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query.Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.FirstOrDefaultAsync(predicate);
    }
}