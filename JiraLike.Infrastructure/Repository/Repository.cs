
namespace JiraLike.Infrastructure.Repository
{
    using JiraLike.Application.Interfaces;
    using JiraLike.Infrastructure.DbContexts;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly JiraLikeDbContext _dbContext;

        public Repository(JiraLikeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(T entity, CancellationToken token)
        {
            await _dbContext.Set<T>().AddAsync(entity, token);
        }

        public async Task SaveChangesAsync(CancellationToken token)
        {
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken token)
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync(token);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { id }, token);
        }

        public async Task UpdateAsync(T entity, CancellationToken token)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task SoftDeleteAsync(T entity, CancellationToken token)
        {
            var entityEntry = _dbContext.Entry(entity);

            if (entityEntry.Property("IsDeleted") != null)
            {
                entityEntry.Property("IsDeleted").CurrentValue = true;
            }
            else
            {
                throw new InvalidOperationException($"{typeof(T).Name} does not support soft delete.");
            }

            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken token)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate, token);
        }

        public IQueryable<T> Query(bool asNoTracking = true)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            return asNoTracking ? query.AsNoTracking() : query;
        }


    }
}
