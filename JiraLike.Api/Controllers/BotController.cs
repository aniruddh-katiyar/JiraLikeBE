namespace JiraLike.Api.Controllers
{
    using JiraLike.Api.services;
    using JiraLike.Api.Services;
    using JiraLike.Application.Dtos;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/bot")]
    public class BotController : ControllerBase
    {
        private readonly BotService _bot;

        public BotController(BotService bot)
        {
            _bot = bot;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] BotRequest request)
        {
            var answer = await _bot.Ask(request.Question);
            return Ok(answer);
        }
    }

}
