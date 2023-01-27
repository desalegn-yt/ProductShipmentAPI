using Microsoft.AspNetCore.Mvc;

namespace SmartNestAPI.Controllers
{
    [Route("Health")]
    [ApiController]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Healthy");
        }
    }
}
