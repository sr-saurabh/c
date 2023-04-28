using CarPoolModels.ApiModels;
using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolServices.IContracts
{
    public interface IBookRidesServices
    {
        List<RideCard> GetMatchedRide(string source, string destination, DateTime date, int time, Guid userId);
        string BookRide(RideCard rideCard, Guid userId);
        List<RideCard>? GetBookedRides(Guid userId);
    }
}
