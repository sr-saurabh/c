using CarPoolModels.ApiModels;
using CarPoolServices.IContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CarPoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookRideController : Controller
    {
        private readonly IBookRidesServices bookRidesServices;
        public BookRideController(IBookRidesServices bookRidesServices)
        {
            this.bookRidesServices = bookRidesServices;
        }

        [HttpGet]
        [Route("get-matched-rides")]
        public IActionResult GetMatchedRides(string source, string destination, DateOnly date, int time)
        {
            Guid userId = new Guid(User.FindFirst("Id").Value);
            var rideCards = bookRidesServices.GetMatchedRide(source, destination, date, time, userId);
            if (rideCards.IsNullOrEmpty())
            {
                return NoContent();
                //return Ok("Rides not found!");
            }
            return Ok(rideCards);
        }

        [HttpGet]
        [Route("book-ride")]
        public IActionResult BookRide(RideCard ride)
        {
            Guid userId = new Guid(User.FindFirst("Id").Value);
            var response =bookRidesServices.BookRide(ride, userId);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-booked-rides")]
        public IActionResult GetBookedRides()
        {
            Guid userId = new Guid(User.FindFirst("Id").Value);

            var bookedRides = bookRidesServices.GetBookedRides(userId);
            if (bookedRides == null)
            {
                return NoContent();
                //return Ok("No booked ride is available!");
            }
            return Ok(bookedRides);
        }

    }
}
