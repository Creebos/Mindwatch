using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using KR.Hanyang.Mindwatch.Domain.Interfaces;

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly MindwatchDbContext _context;
        private IDbContextTransaction? _transaction;

        public GenericRepository(MindwatchDbContext context) => _context = context;

        private DbSet<T> GetDbSet<T>() where T : class => _context.Set<T>();

        public async Task<IEnumerable<T>> FindAllAsync<T>() where T : class
        {
            return await GetDbSet<T>().ToListAsync();
        }

        public async Task<T?> FindByIdAsync<T>(object id) where T : class
        {
            return await GetDbSet<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindByPredicateAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await GetDbSet<T>().Where(predicate).ToListAsync();
        }

        public async Task InsertAsync<T>(T entity) where T : class
        {
            await GetDbSet<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            GetDbSet<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            GetDbSet<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}
