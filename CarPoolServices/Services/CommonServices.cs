using CarPoolModels.ApiModels;
using CarPoolModels.Models;
using CarPoolServices.IContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolServices.Services
{
    public class CommonServices: ICommonServices
    {
        public List<RideCard> CreateRideCard(string source, string destination, List<OfferedRide>? offeredRides, List<BookedRide>? bookedRides, bool isForGetMatch)
        {

            List <RideCard> rideCards = new();
                    RideCard  ridecard= new ();
            if(offeredRides==null)
            {
                for (int i = 0; i < bookedRides.Count(); i++)
                {
                   var  ride= bookedRides[i];
                    ridecard.Id=ride.BookingId;
                    ridecard.Destination=ride.Destination;
                    ridecard.Source=ride.Source;
                    ridecard.Seats = ride.BookedSeats;
                    ridecard.Time = ride.OfferedRide.Time;
                    ridecard.Price = ride.OfferedRide.Price;
                    ridecard.Date = ride.OfferedRide.Date;
                    ridecard.Image = ride.OfferedRide.User.Image;
                    ridecard.Name = ride.OfferedRide.User.UserName;

                    rideCards.Add(ridecard);
                }
                return rideCards;
            }

            if (isForGetMatch)
            {
                for (int i = 0; i < offeredRides.Count(); i++)
                {
                    var ride = offeredRides[i];
                    ridecard.Id = ride.OfferedRideId;
                    ridecard.Destination = destination;
                    ridecard.Source = source;
                    ridecard.Seats = ride.AvailableSeats;
                    ridecard.Time = ride.Time;
                    ridecard.Price = ride.Price;
                    ridecard.Date = ride.Date;
                    ridecard.Image = ride.User.Image;
                    ridecard.Name = ride.User.UserName;

                    rideCards.Add(ridecard);
                }
                return rideCards;
            }
            for (int i = 0; i < offeredRides.Count(); i++)
            {
                var oRide = offeredRides[i];
                ridecard.Id = oRide.OfferedRideId;
                ridecard.Time = oRide.Time;
                ridecard.Price = oRide.Price;
                ridecard.Date = oRide.Date;

                var bRides = oRide.BookedRids.ToList();
                for (int j=0;j<bRides.Count();j++)
                {
                    var bRide = bRides[j];
                    ridecard.Destination = bRide.Destination;
                    ridecard.Source = bRide.Source;
                    ridecard.Seats = bRide.BookedSeats;
                    ridecard.Image = bRide.User.Image;
                    ridecard.Name = bRide.User.UserName;

                    rideCards.Add(ridecard);
                }
            }
            return rideCards;
        }
    }
}
