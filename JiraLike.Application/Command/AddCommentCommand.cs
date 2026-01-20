/// <summary>
/// Command to add a comment to an issue.
/// </summary>
namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Application.Dto;
    using MediatR;

    public sealed class AddCommentCommand : IRequest<CommentResponseDto>
    {
        public Guid ProjectId { get; }
        public Guid IssueId { get; }
        public AddCommentRequestDto Request { get; }

        public AddCommentCommand(Guid projectId, Guid issueId, AddCommentRequestDto request)
        {
            ProjectId = projectId;
            IssueId = issueId;
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }
    }
}
