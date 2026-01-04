/// <summary>
/// UsersController provides RESTful endpoints for managing user accounts in the JiraLike application.
/// </summary>

namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Domain.Dtos;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IMediator mediator, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userRequestDto">User creation request payload</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Returns the created user identifier</returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRequestDto userRequestDto, CancellationToken token)
        {
            var result = await _mediator.Send(new CreateUserCommand(userRequestDto), token);
            return Created($"api/users/{result.UserId}", result);
        }

        /// <summary>
        /// Update User : Partial Updates.
        /// </summary>
        /// <param name="userRequestDto">User creation request payload</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Returns the updated user identifier</returns>
        [HttpPatch("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserRequestDto userRequestDto, [FromRoute] Guid userId, CancellationToken token)
        {
            var result = await _mediator.Send(new UpdateUserCommand(userRequestDto, userId), token);
            return Ok(result);
        }


        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Returns nothing</returns>
        [HttpDelete("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid userId, CancellationToken token)
        {
            await _mediator.Send(new DeleteUserCommand(userId), token);
            return NoContent();
        }


        /// <summary>
        /// Get All Users.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Return List of Users</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsersAsync(CancellationToken token)
        {
            var result = await _mediator.Send(new GetAllUserQuery(), token);
            _logger.LogInformation(
      "CreateUser API called. CorrelationId: {CorrelationId}",
      HttpContext.TraceIdentifier
  );

            return Ok(result);
        }

        /// <summary>
        /// Get User by Id.
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Return Single user by Id</returns>
        [HttpGet("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById([FromRoute] Guid userId, CancellationToken token)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(userId), token);
            return Ok(result);
        }
    }
}
