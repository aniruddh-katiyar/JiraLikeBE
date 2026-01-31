namespace JiraLike.Application.Command.Issue
{
    using JiraLike.Application.Dto.Issue;
    using MediatR;

    public class UpdateIssueCommand : IRequest<UpdateIssueRequestDto>
    {
        public Guid ProjectId { get; }
        public Guid IssueId { get; }
        public UpdateIssueRequestDto UpdateIssueRequestDto { get; }

        public UpdateIssueCommand(Guid projectId, Guid issueId, UpdateIssueRequestDto updateIssueRequestDto)
        {
            ProjectId = projectId;
            IssueId = issueId;
            UpdateIssueRequestDto = updateIssueRequestDto;
        }
    }
}
