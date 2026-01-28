/// <summary>
/// Query to fetch all issues of a project.
/// </summary>
namespace JiraLike.Application.Command.Issue
{
    using JiraLike.Application.Dto.Issue;
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
