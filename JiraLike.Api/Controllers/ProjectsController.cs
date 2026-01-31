namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Command;
    using JiraLike.Application.Command.Project;
    using JiraLike.Application.Dto.Project;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Projects Controller
    /// </summary>
    [ApiController]
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Projects Controller Constructor
        /// </summary>
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST /projects
        /// <summary>
        /// Handles HTTP POST requests to create a new project.
        /// </summary>
        /// <param name="request">
        /// The project creation details provided in the request body, encapsulated in a <see cref="CreateProjectRequestDto"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to monitor for cancellation requests.
        /// </param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing the result of the project creation wrapped in an HTTP 200 OK response.
        /// </returns>

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProjectAsync([FromBody] CreateProjectRequestDto request,
                                                             CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateProjectCommand(request), cancellationToken);
            return Ok(result);
        }

        // GET /projects
        /// <summary>
        /// Handles HTTP GET requests to get all projects.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetProjectsAsync(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send( new GetProjectsQuery(), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // GET /projects/{projectId}
        [HttpGet("{projectId:guid}")]
        public async Task<IActionResult> GetProjectByIdAsync(
            Guid projectId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery(projectId), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // PUT /projects/{projectId}
        [HttpPut("{projectId:guid}")]
        public async Task<IActionResult> UpdateProjectAsync(Guid projectId, [FromBody] UpdateProjectRequestDto request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateProjectCommand(projectId, request), cancellationToken);
            return Ok(result);
        }


    }
}
