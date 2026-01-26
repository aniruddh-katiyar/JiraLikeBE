namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Command;
    using JiraLike.Application.Dto;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Auth Controller
    /// </summary>
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// AuthController constructor
        /// </summary>
        /// <param name="mediator"></param>
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Register User 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // POST /auth/register
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] RegisterUserRequestDto request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new RegisterUserCommand(request),
                cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // POST /auth/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] LoginRequestDto request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new LoginUserCommand(request),
                cancellationToken);

            return Ok(result);
        }

        // POST /auth/refresh
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshTokenAsync(
            [FromBody] RefreshTokenRequestDto request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetRefreshTokenQuery(request.RefreshToken),
                cancellationToken);

            return Ok(result);
        }

        // POST /auth/logout
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync(
            [FromBody] LogoutRequestDto request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new LogoutUserCommand(request.RefreshToken),
                cancellationToken);

            return NoContent();
        }
    }
}
