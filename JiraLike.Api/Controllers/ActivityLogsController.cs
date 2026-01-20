namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Abstraction.Query;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize]
    public class ActivityLogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivityLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /projects/{projectId}/activity
        [HttpGet("api/projects/{projectId:guid}/activity")]
        public async Task<IActionResult> GetProjectActivityAsync(
            Guid projectId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetProjectActivityQuery(projectId),
                cancellationToken);

            return Ok(result);
        }

        // GET /issues/{issueId}/activity
        [HttpGet("api/issues/{issueId:guid}/activity")]
        public async Task<IActionResult> GetIssueActivityAsync(
            Guid issueId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetIssueActivityQuery(issueId),
                cancellationToken);

            return Ok(result);
        }
    }
}
