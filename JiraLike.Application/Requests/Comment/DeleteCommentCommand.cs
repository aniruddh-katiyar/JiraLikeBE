namespace JiraLike.Application.Requests.Comment
{
    using MediatR;
    using System;

    public class DeleteCommentCommand : IRequest<bool>
    {
        public Guid CommentId { get; set; }
        public DeleteCommentCommand(Guid commentId)
        {
            CommentId = commentId;
        }
    }
}
