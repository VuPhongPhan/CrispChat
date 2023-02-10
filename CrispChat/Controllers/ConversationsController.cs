using CrispChat.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrispChat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationsController : ControllerBase
    {
        private readonly IConversationsService _conversationsService;

        public ConversationsController(IConversationsService conversationsService)
        {
            _conversationsService = conversationsService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetConversationsAsync()
        {
            var result = await _conversationsService.GetConversations();
            return Ok(result);
        }

        [HttpGet("message/{sessionId}")]
        public async Task<IActionResult> GetMessagesAsync(string sessionId)
        {
            var result = await _conversationsService.GetMessages(sessionId);
            return Ok(result);
        }

        [HttpGet("routing/{sessionId}")]
        public async Task<IActionResult> GetRoutingAsync(string sessionId)
        {
            //var result = await _conversationsService.
                return Ok();
        }
    }
}
