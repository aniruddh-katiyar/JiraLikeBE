/// <summary>
/// Query to fetch activity logs for an issue.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using JiraLike.Application.Dto;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetIssueActivityQuery : IRequest<List<ActivityLogResponseDto>>
    {
        public Guid IssueId { get; }

        public GetIssueActivityQuery(Guid issueId)
        {
            IssueId = issueId;
        }
    }
}
