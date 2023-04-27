using CarPoolModels.ApiModels;
using CarPoolModels.Models;
using CarPoolServices.IContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarPoolAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OfferRideController : Controller
    {
        private readonly IOfferRideServices _offerRideServices;
        public OfferRideController(IOfferRideServices offerRideServices)
        {
            _offerRideServices = offerRideServices;
        }

        [HttpPost]
        public IActionResult AddOfferRide(OfferedRideWithLocations offeredRide)
        {
            offeredRide.OfferedRides.OfferedBy = new Guid(User.FindFirst("Id").Value);
            var x = _offerRideServices.AddOfferedRide(offeredRide);
            return Ok(x);

        }
    }


}
