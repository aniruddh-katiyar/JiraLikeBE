/// <summary>
/// Query to fetch activity logs for a project.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetProjectActivityQuery : IRequest<List<ActivityLogResponseDto>>
    {
        public Guid ProjectId { get; }

        public GetProjectActivityQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
