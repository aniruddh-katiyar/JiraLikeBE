using JiraLike.Application.Dtos.Comment;
using JiraLike.Application.Requests.Comment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all comments for an issue
    /// </summary>
    // GET /api/projects/{projectId}/issues/{issueId}/comments
    [HttpGet("api/projects/{projectId:guid}/issues/{issueId:guid}/comments")]
    public async Task<IActionResult> GetCommentsAsync(
        Guid projectId,
        Guid issueId,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetAllCommentbyIssueIdQuery(projectId, issueId),
            cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Add comment to an issue
    /// </summary>
    // POST /api/projects/{projectId}/issues/{issueId}/comments
    [HttpPost("api/projects/{projectId:guid}/issues/{issueId:guid}/comments")]
    public async Task<IActionResult> AddCommentAsync(
        Guid projectId,
        Guid issueId,
        [FromBody] CommentDto request,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new AddCommentCommand(request, issueId, projectId),
            cancellationToken);

        return Ok(result);
    }

    ///// <summary>
    ///// Delete comment
    ///// </summary>
    //// DELETE /api/comments/{commentId}
    //[HttpDelete("api/comments/{commentId:guid}")]
    //public async Task<IActionResult> DeleteCommentAsync(
    //    Guid commentId,
    //    CancellationToken cancellationToken)
    //{
    //    var result = await _mediator.Send(
    //        new DeleteCommentCommand(commentId),
    //        cancellationToken);

    //    return Ok(result);
    //}
}