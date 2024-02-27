using CaseForRanna_BackEnd.DataAccess.Context;

namespace CaseForRanna_BackEnd.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork  
    {
        private readonly DbContextForCase _dbContextForCase;

        public UnitOfWork(DbContextForCase dbContextForCase)
        {
            _dbContextForCase = dbContextForCase;
        }

        public void Commit()
        {
            _dbContextForCase.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContextForCase.SaveChangesAsync();
        }
    }
}
