namespace JiraLike.Application.Requests.Comment
{
    using JiraLike.Application.Dtos.Comment;
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetAllCommentbyIssueIdQuery : IRequest<List<CommentResponseDto>>
    {
        public Guid ProjectId { get; set; }

        public Guid IssueId { get; set; }
        public GetAllCommentbyIssueIdQuery(Guid projectId, Guid issueId)
        {
            ProjectId = projectId;
            IssueId = issueId;
        }
    }
}
