using System.Linq.Expressions;

namespace ErpaHolding.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> FindAsync(string id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQuery();
        void Remove(T entity);

        Task CreateAsync(T entity);
        Task CreateListAsync(List<T> entities);

        void Update(T entity);
    }
}
