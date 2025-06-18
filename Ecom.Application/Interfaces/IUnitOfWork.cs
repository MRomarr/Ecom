namespace Ecom.Application.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}
