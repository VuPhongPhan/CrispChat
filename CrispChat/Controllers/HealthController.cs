using Microsoft.AspNetCore.Mvc;

namespace CrispChat.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            await Task.Yield();
            return Ok("pong");
        }
    }
}
