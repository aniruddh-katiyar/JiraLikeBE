namespace JiraLike.Api.Controllers
{
    using JiraLike.Application.Dtos.Comment;
    using JiraLike.Application.Requests.Comment;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    [ApiController]
    [Route("api/auth")]
    public class CommentsController : ControllerBase
    {
        private IMediator _mediator;
        /// <summary>
        /// In Memory 
        /// </summary>
        /// <param name="mediator"></param>
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentDto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCommentByIssueIdAsync([FromBody]CommentDto commentDto, CancellationToken token)
        {
            var result = await _mediator.Send(new AddCommentCommand(commentDto), token);
            return Ok(result);
        }

        [HttpGet]
        public async void AddCommentAsync()
        {

        }
        
    }
}
