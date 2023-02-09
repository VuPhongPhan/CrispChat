using Microsoft.AspNetCore.Mvc;

namespace CrispChat.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
