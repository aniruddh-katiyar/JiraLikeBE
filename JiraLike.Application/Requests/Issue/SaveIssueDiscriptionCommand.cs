namespace JiraLike.Application.Requests.Issue
{
    using JiraLike.Application.Dtos.Issue;
    using MediatR;

    public class SaveIssueDiscriptionCommand : IRequest<string>
    {
        public SaveIssueDiscriptionDto SaveIssueDiscriptionDto { get; set; }

        public Guid ProjectId { get; set; }

        public Guid IssueId { get; set; }

        public SaveIssueDiscriptionCommand( Guid projectId, Guid issueId, SaveIssueDiscriptionDto saveIssueDiscriptionDto)
        {
            SaveIssueDiscriptionDto = saveIssueDiscriptionDto;
            ProjectId = projectId;
            IssueId = issueId;
        }
    }
}
