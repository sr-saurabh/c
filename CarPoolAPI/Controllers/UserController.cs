using Microsoft.AspNetCore.Mvc;

namespace CarPoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("get-booked-rides")]
        public IActionResult GetBookedRides()
        {
            return Ok();
        }

        [HttpGet]
        [Route("get-offered-rides")]
        public IActionResult GetOfferedRides()
        {
            return Ok();
        }

        
    }
}
