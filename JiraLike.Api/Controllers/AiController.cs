//--
//Ai Controller : it Contain all ai related endpoints.
//this controller does not contain any operation which leads to automatic db operations .
//it is used only for get summary and improve respone
//--
namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Command.Ai;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// All Ai realted Endpoints.
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("api/ai")]
    public class AiController : ControllerBase
    {
        //private readonly ChatService _chatService;
        private readonly IMediator _mediator;

        /// <summary>
        /// AiConstructor
        /// </summary>
        /// <param name="mediator"></param>
        public AiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Improve Project Summary With AI 
        /// </summary>
        /// <param name="RawDiscription"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // POST /api/ai/projectdiscription
        [HttpPost("projectdiscription")]
        public async Task<IActionResult> ImproveProjectDiscriptionAsync(
            [FromBody] string RawDiscription,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ImproveProjectDiscriptionRequestQuery(RawDiscription), cancellationToken);
            return Ok(response);
        }
    }
}
