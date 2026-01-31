namespace JiraLike.Infrastructure.Repositories
{
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Infrastructure.DbContexts;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        private readonly JiraLikeDbContext _jiraLikeDbContext;

        public UserRepository(JiraLikeDbContext jiraLikeDbContext)
        {
            _jiraLikeDbContext = jiraLikeDbContext;
        }

        public async Task<string> GetUserNameAsync(Guid userid, CancellationToken token)
        {
            var userName = await _jiraLikeDbContext.Users.AsNoTracking().Where(user => user.Id == userid)
                 .Select(user => new
                 {
                     user.Name
                 }).FirstOrDefaultAsync(token);

            return userName!.Name;
        }
    }
}
