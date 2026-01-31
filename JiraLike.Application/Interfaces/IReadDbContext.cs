namespace JiraLike.Application.Interfaces
{
    using JiraLike.Domain.Entities;
    using JiraLike.Domain.Token;

    public interface IReadDbContext
    {
        IQueryable<ActivityLogEntity> ActivityLogs { get; }
        IQueryable<ChatHistoryEntity> ChatHistories { get; }
        IQueryable<CommentEntity> Comments { get; }
        IQueryable<IssueEntity> Issues { get; }
        IQueryable<ProjectEntity> Projects { get; }
        IQueryable<ProjectUserEntity> ProjectUsers { get; }
        IQueryable<RefreshTokenEntity> RefreshTokens { get; }
        IQueryable<RoleEntity> Roles { get; }
        IQueryable<UserEntity> Users { get; }
    }

}
