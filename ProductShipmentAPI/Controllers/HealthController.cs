using Microsoft.AspNetCore.Mvc;

namespace ProductShipmentAPI.Controllers
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
