/// <summary>
/// Command to assign an issue to a user.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using MediatR;

    public sealed class AssignIssueCommand : IRequest
    {
        public Guid ProjectId { get; }
        public Guid IssueId { get; }
        public Guid AssigneeId { get; }

        public AssignIssueCommand(Guid projectId, Guid issueId, Guid assigneeId)
        {
            ProjectId = projectId;
            IssueId = issueId;
            AssigneeId = assigneeId;
        }
    }
}
