/// <summary>
/// Command to create an issue (Epic, Story, Task, Bug).
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Application.Dto;
    using MediatR;

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
