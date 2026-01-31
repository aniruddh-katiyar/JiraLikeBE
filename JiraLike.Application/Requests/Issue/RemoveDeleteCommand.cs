namespace JiraLike.Application.Requests.Issue
{
    using MediatR;

    public class RemoveIssueCommand : IRequest<bool>
    {
        public Guid IssueId { get; }

        public RemoveIssueCommand(Guid issueId)
        {
            IssueId = issueId;
        }
    }
}
