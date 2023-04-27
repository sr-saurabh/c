using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolDbContext.IRepository
{
    public interface IOfferRideRepository
    {
        string AddOfferedRide(OfferedRide ride);
    }
}
