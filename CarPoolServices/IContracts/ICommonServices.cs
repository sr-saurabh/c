using CarPoolModels.ApiModels;
using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolServices.IContracts
{
    public interface ICommonServices
    {
        List<RideCard> CreateRideCard(string source, string destination, List<OfferedRide>? offeredRides, List<BookedRide>? bookedRides, bool isForGetMatch);
    }
}
