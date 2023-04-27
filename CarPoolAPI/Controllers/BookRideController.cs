using Microsoft.AspNetCore.Mvc;

namespace CarPoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookRideController : Controller
    {
        [HttpGet]
        [Route("get-matched-rides")]
        public IActionResult GetMatchedRides(string from, string to, DateTime date, int time, int seats)
        {
            return Ok();
        }

        [HttpGet]
        [Route("book-ride")]
        public IActionResult BookRide()
        {
            return Ok();
        }

    }
}
