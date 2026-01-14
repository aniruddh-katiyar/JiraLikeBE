namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Abstraction.Command;
    using JiraLike.Application.Abstraction.Query;
    using JiraLike.Application.Dtos;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto loginRequestDto, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new LoginUserCommand(loginRequestDto), cancellationToken);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> GetRefreshTokenAsync([FromBody] string refreshToken, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetRefreshTokenQuery(refreshToken), cancellationToken);
            return Ok(result);
        }
    }
}
