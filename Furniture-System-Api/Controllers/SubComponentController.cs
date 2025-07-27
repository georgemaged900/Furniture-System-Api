using Furniture_System_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Furniture_System_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SubComponentController : ControllerBase
    {
        private readonly ISubComponentService _subComponentService;
        public SubComponentController(ISubComponentService subComponentService)
        {
            _subComponentService = subComponentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
