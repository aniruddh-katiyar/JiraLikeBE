//--
// Command to create an issue (Epic, Story, Task, Bug).
//--
namespace JiraLike.Application.Command.Issue
{
    using JiraLike.Application.Dto.Issue;
    using MediatR;

    /// <summary>
    /// Command to create an issue (Epic, Story, Task, Bug).
    /// </summary>
    public sealed class CreateIssueCommand : IRequest<IssueResponseDto>
    {
        public Guid ProjectId { get; }
        public CreateIssueRequestDto Request { get; }

        public CreateIssueCommand(Guid projectId, CreateIssueRequestDto request)
        {
            ProjectId = projectId;
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }
    }
}
