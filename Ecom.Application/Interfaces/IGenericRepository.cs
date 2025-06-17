using System;
using System.Linq.Expressions;

namespace Ecom.Application.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[]? includes);
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[]? includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
