using Microsoft.AspNetCore.Mvc;

namespace SmartNestAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("test");
            return Ok("Healthy");
        }
    }
}
