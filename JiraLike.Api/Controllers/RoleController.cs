namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Command;
    using JiraLike.Application.Dto;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync(
          [FromBody] RoleRequestDto roleRequest,
           CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new AddRoleCommand(roleRequest),
                cancellationToken);

            return NoContent();
        }
    }
}
