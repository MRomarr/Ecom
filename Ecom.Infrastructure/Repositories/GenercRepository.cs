using System.Linq.Expressions;
using Ecom.Application.Interfaces;
using Ecom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Infrastructure.Repositories
{
    public class GenercRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenercRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[]? includes)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[]? includes)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

            return await query.AsNoTracking().SingleOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);

        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if(entity is not null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
}
