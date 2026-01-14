namespace JiraLike.Application.Interfaces
{
    using System.Linq.Expressions;

    //Generic Repository
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken token);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken token);
        Task AddAsync(T entity, CancellationToken token);
        Task UpdateAsync(T entity, CancellationToken token);
        Task SoftDeleteAsync(T entity, CancellationToken token);
        Task SaveChangesAsync(CancellationToken token);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken token);

        IQueryable<T> Query(bool asNoTracking = true);

    }
}
