namespace JiraLike.Application.Handler.Comment
{
    using JiraLike.Application.Dtos.Comment;
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Requests.Comment;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllCommentbyIssueIdHandler : IRequestHandler<GetAllCommentbyIssueIdQuery, List<CommentResponseDto>>
    {
        private readonly IReadDbContext _readDbContext;
        public GetAllCommentbyIssueIdHandler(IReadDbContext readDbContext)
        {
            _readDbContext = readDbContext; 
        }
        public async Task<List<CommentResponseDto>> Handle(GetAllCommentbyIssueIdQuery request, CancellationToken cancellationToken)
        {
            if(request.ProjectId == Guid.Empty || request.IssueId == Guid.Empty)
            {
                throw new ArgumentNullException("Missing Project Id or Issue Id !");
            }

            var IsIssueExist = await _readDbContext.Issues.AnyAsync(issue => issue.Id == request.IssueId, cancellationToken);

            if (IsIssueExist)
            {
                var result = await _readDbContext.Comments.Where(c => c.ProjectId == request.ProjectId && c.IssueId == request.IssueId).Select
                    (x => new CommentResponseDto
                    {
                        Content = x.Content,
                        CommentDate = x.CreatedAt,
                        UserName = x.User.Name,
                        CommentId = x.Id
                    }
                    ).OrderByDescending(x => x.CommentDate).ToListAsync(cancellationToken);

                return result;
            }
            throw new ArgumentException($"Issue not found for {request.IssueId} !");
        }
    }
}
