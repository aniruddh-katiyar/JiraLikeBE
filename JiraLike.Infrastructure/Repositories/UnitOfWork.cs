namespace JiraLike.Infrastructure.Repositories
{
    using JiraLike.Application.Interfaces;
    using JiraLike.Infrastructure.DbContexts;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly JiraLikeDbContext _JiraLikeDbContext;

        public UnitOfWork(JiraLikeDbContext JiraLikeDbContext)
        {
            _JiraLikeDbContext = JiraLikeDbContext;
        }

        public async Task SaveChangesAsync(CancellationToken ck)
        {
           await _JiraLikeDbContext.SaveChangesAsync(ck);
        }
    }
}
