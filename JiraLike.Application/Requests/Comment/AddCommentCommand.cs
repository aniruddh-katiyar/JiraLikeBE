namespace JiraLike.Application.Requests.Comment
{
    using JiraLike.Application.Dtos.Comment;
    using MediatR;

    public class AddCommentCommand : IRequest<Guid>
    {
        public Guid IssueId { get; set; }

        public Guid ProjectId { get; set; }
        public CommentDto CommentDto { get; set; }
        public AddCommentCommand(CommentDto commentDto, Guid issueId, Guid projectId)
        {
            CommentDto = commentDto;
            IssueId = issueId;
            ProjectId = projectId;
        }
    }
}
