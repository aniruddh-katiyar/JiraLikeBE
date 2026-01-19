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
    public class ProjectUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /projects/{projectId}/users
        [HttpGet("api/projects/{projectId:guid}/users")]
        public async Task<IActionResult> GetProjectUsersAsync(
            Guid projectId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetProjectUsersQuery(projectId),
                cancellationToken);

            return Ok(result);
        }

        // POST /projects/{projectId}/users
        [HttpPost("api/projects/{projectId:guid}/users")]
        public async Task<IActionResult> AddUserToProjectAsync(
            Guid projectId,
            [FromBody] AddProjectUserRequestDto request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new AddUserToProjectCommand(projectId, request),
                cancellationToken);

            return Ok(result);
        }

        // PATCH /projects/{projectId}/users/{userId}/role
        [HttpPatch("api/projects/{projectId:guid}/users/{userId:guid}/role")]
        public async Task<IActionResult> ChangeUserRoleAsync(
            Guid projectId,
            Guid userId,
            [FromBody] ChangeProjectUserRoleRequestDto request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new ChangeUserRoleCommand(projectId, userId, request.RoleId),
                cancellationToken);

            return NoContent();
        }

        // PATCH /projects/{projectId}/users/{userId}/remove
        [HttpPatch("api/projects/{projectId:guid}/users/{userId:guid}/remove")]
        public async Task<IActionResult> RemoveUserFromProjectAsync(
            Guid projectId,
            Guid userId,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new RemoveUserFromProjectCommand(projectId, userId),
                cancellationToken);

            return NoContent();
        }
    }
}
