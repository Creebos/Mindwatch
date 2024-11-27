using System.Linq.Expressions;

namespace KR.Hanyang.Mindwatch.Domain.Interfaces
{
    public interface IGenericRepository
    {
        Task<IEnumerable<T>> FindAllAsync<T>() where T : class;
        Task<T?> FindByIdAsync<T>(object id) where T : class;
        Task<IEnumerable<T>> FindByPredicateAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task InsertAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
