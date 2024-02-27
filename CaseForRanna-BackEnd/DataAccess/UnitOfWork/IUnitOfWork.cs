namespace CaseForRanna_BackEnd.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
