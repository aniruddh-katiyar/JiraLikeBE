//--
// This controller gives activity log.
//--
namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Command.Activitylog;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// ActivitylogsController
    /// </summary>
    [ApiController]
    [Authorize]
    public class ActivityLogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Activity log constructor
        /// </summary>
        /// <param name="mediator"></param>
        public ActivityLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// It Gives project realted activity logs.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // GET /projects/{projectId}/activity
        [HttpGet("api/projects/{projectId:guid}/activity")]
        public async Task<IActionResult> GetProjectActivityAsync(Guid projectId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProjectActivityQuery(projectId), cancellationToken);
            return Ok(result);
        }
    }
}
