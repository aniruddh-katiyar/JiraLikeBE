namespace JiraLike.Application.Handler.ActivityLog
{
    using JiraLike.Application.Command.Activitylog;
    using JiraLike.Application.Dto.ActivityLog;
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Domain.Entities;
    using MediatR;

    public class GetProjectActivityHandler
        : IRequestHandler<GetProjectActivityQuery, IReadOnlyList<ActivityLogResponseDto>>
    {
        private readonly IActivityLogRepository _activityLogRepo;

        public GetProjectActivityHandler(
            IActivityLogRepository activityLogRepo)
        {
            _activityLogRepo = activityLogRepo;
        }

        public async Task<IReadOnlyList<ActivityLogResponseDto>> Handle(
            GetProjectActivityQuery request,
            CancellationToken cancellationToken)
        {
            return await _activityLogRepo.GetActivityLogHistoryByProjecIdAsync(request.ProjectId, cancellationToken);
        }
    }
}

