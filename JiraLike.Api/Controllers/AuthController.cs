namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Dto;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
