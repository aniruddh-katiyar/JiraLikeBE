/// <summary>
/// Query to fetch a single issue by id.
/// </summary>
namespace JiraLike.Application.Abstraction.Query
{
    using JiraLike.Application.Dto;
    using JiraLike.Application.Dto;
    using MediatR;

    public sealed class GetIssueByIdQuery : IRequest<IssueResponseDto>
    {
        public Guid ProjectId { get; }
        public Guid IssueId { get; }

        public GetIssueByIdQuery(Guid projectId, Guid issueId)
        {
            ProjectId = projectId;
            IssueId = issueId;
        }
    }
}
