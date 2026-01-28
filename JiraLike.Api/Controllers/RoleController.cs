namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Command.Role;
    using JiraLike.Application.Dto.Role;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRoleAsync([FromBody] RoleRequestDto roleRequest, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddRoleCommand(roleRequest), cancellationToken);
            return NoContent();
        }
    }
}
