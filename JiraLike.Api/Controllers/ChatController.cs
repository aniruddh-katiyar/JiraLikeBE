//namespace JiraLike.Api.Controllers
//{
//    using JiraLike.Api.Services;
//    using JiraLike.Application.Dto;
//    using MediatR;
//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Mvc;

//    [ApiController]
//    [Authorize]
//    [Route("api/chat")]
//    public class ChatController : ControllerBase
//    {
//        private readonly ChatService _chatService;

//        public ChatController(ChatService chatService)
//        {
//            _chatService = chatService;
//        }

//        // POST /api/chat/query
//        [HttpPost("query")]
//        public async Task<IActionResult> QueryAsync(
//            [FromBody] ChatRequestDto request,
//            CancellationToken cancellationToken)
//        {
//            //var response = await _chatService.HandleAsync(
//            //    request.ProjectId,
//            //    request.Question,
//            //    cancellationToken);
//            var response = await _chatService.HandleAsync(
              
//                request.Question
//                );

//            return Ok(response);
//        }
//    }
//}
