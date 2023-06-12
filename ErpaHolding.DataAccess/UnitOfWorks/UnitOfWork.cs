using ErpaHolding.DataAccess.Contexts;

namespace ErpaHolding.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ErpaHoldingDBContext _dbContext;

        public UnitOfWork(ErpaHoldingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
           _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
