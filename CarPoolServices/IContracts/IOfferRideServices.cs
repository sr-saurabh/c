using CarPoolModels.ApiModels;
using CarPoolModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolServices.IContracts
{
    public interface IOfferRideServices
    {
        Response AddOfferedRide(OfferedRideWithLocations ride);
        List<RideCard>? GetOfferedRides(Guid userId);
    }
}
