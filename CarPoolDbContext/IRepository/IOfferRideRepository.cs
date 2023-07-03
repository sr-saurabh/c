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
        void AddStoppages(List<Stoppage> stoppages);
        List<OfferedRide> GetMatchedRide(int source, int destination, DateOnly date, int time, Guid userId);
        void UpdateOfferedRide(Guid offeredRideId, int bookedSeats);
        bool IsSeatsAvailable(int seats, Guid id);
        List<OfferedRide>? GetOfferedRides(Guid userId);
    }
}
