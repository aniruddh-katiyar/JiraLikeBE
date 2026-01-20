/// <summary>
/// Query to fetch blocked issues in a project.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using JiraLike.Application.Dto;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetBlockedIssuesQuery : IRequest<List<IssueResponseDto>>
    {
        public Guid ProjectId { get; }

        public GetBlockedIssuesQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
