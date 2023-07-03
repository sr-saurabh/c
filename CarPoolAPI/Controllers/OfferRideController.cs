using CarPoolModels.ApiModels;
using CarPoolModels.Models;
using CarPoolServices.IContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json;

namespace CarPoolAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OfferRideController : Controller
    {
        private readonly IOfferRideServices offerRideServices;

        public OfferRideController(IOfferRideServices offerRideServices)
        {
            this.offerRideServices = offerRideServices;
        }

        [HttpPost]
        public IActionResult AddOfferRide(OfferedRideWithLocations rideDetail)
        {
            rideDetail.OfferedRides.UserId = new Guid(User.FindFirst("Id").Value);
            var x = offerRideServices.AddOfferedRide(rideDetail);
            return Ok(x);
            //return Ok(x);
        }

        [HttpGet]
        [Route("get-offered-rides")]
        public IActionResult GetOfferedRides()
        {
            Guid userId = new Guid(User.FindFirst("Id").Value);
            var offeredRides=offerRideServices.GetOfferedRides(new Guid(User.FindFirst("Id").Value));
            if(offeredRides==null)
            {
                return NoContent();
            }

            return Ok(offeredRides);
        }
    }


}
