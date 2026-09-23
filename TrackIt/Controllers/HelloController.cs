using Microsoft.AspNetCore.Mvc;
using TrackIt.Application.Services;

namespace TrackIt.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly IGreetingService _greetingService;

        public HelloController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var message = _greetingService.GetGreeting();
            return Ok(message);
        }
    }

}
