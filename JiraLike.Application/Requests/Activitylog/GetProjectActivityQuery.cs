/// <summary>
/// Query to fetch activity logs for a project.
/// </summary>
namespace JiraLike.Application.Command.Activitylog
{
    using JiraLike.Application.Dto.ActivityLog;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetProjectActivityQuery : IRequest<IReadOnlyList<ActivityLogResponseDto>>
    {
        public Guid ProjectId { get; }

        public GetProjectActivityQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
