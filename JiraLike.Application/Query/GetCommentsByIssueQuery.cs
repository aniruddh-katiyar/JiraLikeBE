/// <summary>
/// Query to fetch comments of an issue.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using JiraLike.Application.Dto;
    using MediatR;
    using System.Collections.Generic;

    public sealed class GetCommentsByIssueQuery : IRequest<List<CommentResponseDto>>
    {
        public Guid ProjectId { get; }
        public Guid IssueId { get; }

        public GetCommentsByIssueQuery(Guid projectId, Guid issueId)
        {
            ProjectId = projectId;
            IssueId = issueId;
        }
    }
}
