namespace JiraLike.Application.Requests.Comment
{
    using JiraLike.Application.Dtos.Comment;
    using MediatR;

    public class AddCommentCommand : IRequest<Guid>
    {
        public CommentDto CommentDto { get; set; }
        public AddCommentCommand(CommentDto commentDto)
        {
            CommentDto = commentDto;
        }
    }
}
