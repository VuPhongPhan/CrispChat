using CrispChat.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrispChat.Controllers
{
    [ApiController]
    [Route("api")]
    public class ConversationsController : ControllerBase
    {
        private readonly IConversationsService _conversationsService;

        public ConversationsController(IConversationsService conversationsService)
        {
            _conversationsService = conversationsService;
        }

        [HttpGet("conversation")]
        public async Task<IActionResult> GetConversationsAsync()
        {
            var start = new DateTime(year: 2000, month: 01, day: 01);
            var end = DateTime.UtcNow;
            var result = await _conversationsService.GetConversationsAsync(start, end);
            return Ok(result);
        }

        [HttpGet("people")]
        public async Task<IActionResult> GetPeopleAsync()
        {
            var start = new DateTime(year: 2000, month: 01, day: 01);
            var end = DateTime.UtcNow;
            var result = await _conversationsService.GetPeoplesAsync(start, end);
            return Ok(result);
        }

        [HttpGet("visitor")]
        public async Task<IActionResult> GetVisitorAsync()
            => Ok(await _conversationsService.GetVisitorsAsync());

        [HttpGet("website/{websiteId}")]
        public async Task<IActionResult> GetWebsiteAsync(string websiteId)
            => Ok(await _conversationsService.GetWebsite(websiteId));
    }
}
