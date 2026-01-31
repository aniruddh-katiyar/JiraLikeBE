/// <summary>
/// Command to update issue status.
/// </summary>
namespace JiraLike.Application.Command.Issue
{
    using MediatR;

    public sealed class UpdateIssueStatusCommand : IRequest
    {
        public Guid ProjectId { get; }
        public Guid IssueId { get; }
        public string Status { get; }

        public UpdateIssueStatusCommand(Guid projectId, Guid issueId, string status)
        {
            ProjectId = projectId;
            IssueId = issueId;
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }
    }
}
