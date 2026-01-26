namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Dto;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /users
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync(CancellationToken token)
        {
            var result = await _mediator.Send(new GetAllUserQuery(), token);
            return Ok(result);
        }

        // GET /users/{id}
        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid userId, CancellationToken token)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(userId), token);
            return Ok(result);
        }

        // PATCH /users/{id}
        [HttpPatch("{userId:guid}")]
        public async Task<IActionResult> UpdateUserAsync(
            Guid userId,
            [FromBody] UpdateUserRequestDto request,
            CancellationToken token)
        {
            var result = await _mediator.Send(
                new UpdateUserCommand(request, userId),
                token);

            return Ok(result);
        }

        // PATCH /users/{id}/deactivate
        [HttpPatch("{userId:guid}/deactivate")]
        public async Task<IActionResult> DeactivateUserAsync(Guid userId, CancellationToken token)
        {
            await _mediator.Send(new DeactivateUserCommand(userId), token);
            return NoContent();
        }
    }
}
