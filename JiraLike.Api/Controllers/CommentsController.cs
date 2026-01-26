namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Dto;
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

        // POST /projects/{projectId}/issues/{issueId}/comments
        [HttpPost("api/projects/{projectId:guid}/issues/{issueId:guid}/comments")]
        public async Task<IActionResult> AddCommentAsync(
            Guid projectId,
            Guid issueId,
            [FromBody] AddCommentRequestDto request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new AddCommentCommand(projectId, issueId, request),
                cancellationToken);

            return Ok(result);
        }

        // GET /projects/{projectId}/issues/{issueId}/comments
        [HttpGet("api/projects/{projectId:guid}/issues/{issueId:guid}/comments")]
        public async Task<IActionResult> GetCommentsAsync(
            Guid projectId,
            Guid issueId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetCommentsByIssueQuery(projectId, issueId),
                cancellationToken);

            return Ok(result);
        }
    }
}
