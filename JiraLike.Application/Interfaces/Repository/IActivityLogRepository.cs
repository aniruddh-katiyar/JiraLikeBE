namespace JiraLike.Application.Interfaces.Repository
{
    using JiraLike.Application.Dto.ActivityLog;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IActivityLogRepository
    {
        Task<IReadOnlyList<ActivityLogResponseDto>> GetActivityLogHistoryByProjecIdAsync(Guid projectId, CancellationToken token);
    }
}
