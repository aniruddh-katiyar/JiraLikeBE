using JiraLike.Application.Abstraction.Command;
using JiraLike.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JiraLike.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] UserRequestDto userRequestDto, CancellationToken token )
        {
            var result = await _mediator.Send(new AddUserCommand(userRequestDto), token);
            return Created(result);
        }
    }
}
