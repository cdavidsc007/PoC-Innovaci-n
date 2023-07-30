namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
        IGenericRepository<T> Repository<T>() where T : class;
        void Rollback();
    }
}