

namespace JiraLike.Application.Abstraction.Services
{
    using System.Linq.Expressions;

    //Generic Repository
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task AddAsync(T entity, CancellationToken token);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync(CancellationToken token);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken token);
    }
}
