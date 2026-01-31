namespace JiraLike.Infrastructure.Repositories
{
    using JiraLike.Application.Interfaces;
    using JiraLike.Domain.Entities;
    using JiraLike.Domain.Token;
    using JiraLike.Infrastructure.DbContexts;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class ReadDbContext  : IReadDbContext
    {
        private readonly JiraLikeDbContext _dbContext;
        public ReadDbContext(JiraLikeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<ActivityLogEntity> ActivityLogs
            => _dbContext.ActivityLogs.AsNoTracking();

        public IQueryable<ChatHistoryEntity> ChatHistories
            => _dbContext.ChatHistory.AsNoTracking();

        public IQueryable<CommentEntity> Comments
            => _dbContext.Comments.AsNoTracking();

        public IQueryable<IssueEntity> Issues
            => _dbContext.Issues.AsNoTracking();

        public IQueryable<ProjectEntity> Projects
            => _dbContext.Projects.AsNoTracking();

        public IQueryable<ProjectUserEntity> ProjectUsers
            => _dbContext.ProjectUsers.AsNoTracking();

        public IQueryable<RefreshTokenEntity> RefreshTokens
            => _dbContext.RefreshTokens.AsNoTracking();

        public IQueryable<RoleEntity> Roles
            => _dbContext.RoleEntities.AsNoTracking();

        public IQueryable<UserEntity> Users
            => _dbContext.Users.AsNoTracking();
    }
}
