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
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST /projects
        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync(
            [FromBody] CreateProjectRequestDto request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new CreateProjectCommand(request),
                cancellationToken);

            return Ok(result);
        }

        // GET /projects
        [HttpGet]
        public async Task<IActionResult> GetProjectsAsync(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetProjectsQuery(),
                cancellationToken);

            return Ok(result);
        }

        // GET /projects/{projectId}
        [HttpGet("{projectId:guid}")]
        public async Task<IActionResult> GetProjectByIdAsync(
            Guid projectId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetProjectByIdQuery(projectId),
                cancellationToken);

            return Ok(result);
        }

        // PUT /projects/{projectId}
        [HttpPut("{projectId:guid}")]
        public async Task<IActionResult> UpdateProjectAsync(
            Guid projectId,
            [FromBody] UpdateProjectRequestDto request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new UpdateProjectCommand(projectId, request),
                cancellationToken);

            return Ok(result);
        }

        // PATCH /projects/{projectId}/archive
        [HttpPatch("{projectId:guid}/archive")]
        public async Task<IActionResult> ArchiveProjectAsync(
            Guid projectId,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new ArchiveProjectCommand(projectId),
                cancellationToken);

            return NoContent();
        }
    }
}
