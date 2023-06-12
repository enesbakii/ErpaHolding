using ErpaHolding.DataAccess.Contexts;
using ErpaHolding.DataAccess.Interfaces;
using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ErpaHolding.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ErpaHoldingDBContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(ErpaHoldingDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet=_dbContext.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public async Task CreateListAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<T> FindAsync(string id)
        {
           return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _dbSet.AsNoTracking().SingleOrDefaultAsync(filter) : await _dbSet.SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQuery()
        {
            return _dbSet.AsQueryable();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);  
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
