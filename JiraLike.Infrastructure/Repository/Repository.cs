
namespace JiraLike.Infrastructure.Repository
{
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Infrastructure.DbContexts;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public class Repository<T> : IRepository<T> where T : class
    {
        //DbContext 
        protected readonly JiraLikeDbContext _dbContext;

        public Repository(JiraLikeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //
        public async Task AddAsync(T entity, CancellationToken token)
        {
            await _dbContext.Set<T>().AddAsync(entity, token);
        }

        public async Task SaveChangesAsync(CancellationToken token)
        {
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return;

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken token)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate, token);
        }
    }
}
