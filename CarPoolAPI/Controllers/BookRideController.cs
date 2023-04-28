using CarPoolModels.ApiModels;
using CarPoolServices.IContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetMatchedRides(string source, string destination, DateTime date, int seats)
        {
            Guid userId = new Guid(User.FindFirst("Id").Value);
            var rideCards=bookRidesServices.GetMatchedRide(source, destination, date, seats, userId);
            if (rideCards == null)
                return Ok("Rides not found!");
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
                return Ok("No booked ride is available!");
            return Ok(bookedRides);
        }

    }
}
