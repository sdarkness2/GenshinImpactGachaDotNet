using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GachaController : Controller
    {
        public GachaController()
        {
        }

        [HttpGet("OnePull")]
        public IActionResult OnePull()
        {
            return View();
        }

        [HttpGet("TenPull")]
        public IActionResult TenPull()
        {
            return View();
        }
    }
}
