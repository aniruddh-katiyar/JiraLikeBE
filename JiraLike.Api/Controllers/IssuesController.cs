//--
//This is used to create issur  || Epic || Story || Task || Subtask ||Bug
//This  is Center controller.
//
namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Command.Issue;
    using JiraLike.Application.Dto.Isssue;
    using JiraLike.Application.Dto.Issue;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Issues Controller
    /// </summary>
    [ApiController]
    [Authorize]
    public class IssuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// This is Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public IssuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /projects/{projectId}/issues
        /// <summary>
        /// Get issues by ProjojectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/projects/{projectId:guid}/issues")]
        public async Task<IActionResult> GetIssuesAsync(Guid projectId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetIssuesByProjectQuery(projectId), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="issueId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // GET /projects/{projectId}/issues/{issueId}
        [HttpGet("api/projects/{projectId:guid}/issues/{issueId:guid}")]
        public async Task<IActionResult> GetIssueByIdAsync(Guid projectId, Guid issueId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetIssueByIdQuery(projectId, issueId), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// create Issue
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // POST /projects/{projectId}/issues
        [HttpPost("api/projects/{projectId:guid}/issues")]
        public async Task<IActionResult> CreateIssueAsync(Guid projectId, [FromBody] CreateIssueRequestDto request,
                                                          CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateIssueCommand(projectId, request), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="issueId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // PUT /projects/{projectId}/issues/{issueId}
        [HttpPut("api/projects/{projectId:guid}/issues/{issueId:guid}")]
        public async Task<IActionResult> UpdateIssueAsync(Guid projectId, Guid issueId, [FromBody] UpdateIssueRequestDto request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateIssueCommand(projectId, issueId, request), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="issueId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // PATCH /projects/{projectId}/issues/{issueId}/status
        [HttpPatch("api/projects/{projectId:guid}/issues/{issueId:guid}/status")]
        public async Task<IActionResult> UpdateIssueStatusAsync(Guid projectId, Guid issueId,
            [FromBody] UpdateIssueStatusRequestDto request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateIssueStatusCommand(projectId, issueId, request.Status),
                cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="issueId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // PATCH /projects/{projectId}/issues/{issueId}/assign
        [HttpPatch("api/projects/{projectId:guid}/issues/{issueId:guid}/assign")]
        public async Task<IActionResult> AssignIssueAsync(Guid projectId, Guid issueId,
            [FromBody] AssignIssueRequestDto request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new AssignIssueCommand(projectId, issueId, request.AssigneeId),
                cancellationToken);
            return NoContent();
        }
    }
}
