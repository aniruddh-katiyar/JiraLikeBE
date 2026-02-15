namespace JiraLike.Infrastructure.Repositories
{
    using JiraLike.Application.Dto.ActivityLog;
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Infrastructure.DbContexts;
    using Microsoft.EntityFrameworkCore;

    public class ActivityLogRepository : IActivityLogRepository
    {
        private readonly JiraLikeDbContext _jiraLikeDbContext;

        private readonly IUserRepository _userRepo;

        public ActivityLogRepository(JiraLikeDbContext jiraLikeDbContext, IUserRepository userRepo)
        {
            _jiraLikeDbContext = jiraLikeDbContext;
            _userRepo = userRepo;
        }

        public async Task<IReadOnlyList<ActivityLogResponseDto>> GetActivityLogHistoryByProjecIdAsync(Guid projectId, CancellationToken token)
        {

            return await _jiraLikeDbContext.ActivityLogs.AsNoTracking().Where(activity => activity.ProjectId == projectId)
                  .OrderByDescending(activity => activity.CreatedAt).Take(10).Select(activity => new ActivityLogResponseDto
                  {
                      Action = activity.Action,
                      CreatedAt = activity.CreatedAt,
                      EntityType = activity.EntityType,
                      PerformedBy = activity.PerformedBy,
                      PerformByName = activity.PerformedByName,
                      NewValue = activity.NewValue,
                      EntityId = activity.EntityId,
                      OldValue = activity.OldValue

                  }).ToListAsync(token);
        }


    }
}
