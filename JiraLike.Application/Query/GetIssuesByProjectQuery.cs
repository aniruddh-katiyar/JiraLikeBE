/// <summary>
/// Query to fetch all issues of a project.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using JiraLike.Application.Dto;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetIssuesByProjectQuery : IRequest<List<IssueResponseDto>>
    {
        public Guid ProjectId { get; }

        public GetIssuesByProjectQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
