using CarPoolDbContext.IRepository;
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
    public class BookRidesServices: IBookRidesServices
    {
        private readonly IOfferRideRepository offerRideRepository;
        private readonly ILocationServices locationServices;
        private readonly ICommonServices commonServices;
        private readonly IBookRidesRepository bookRidesRepository;


        public BookRidesServices(IOfferRideRepository offerRideRepository, ILocationServices locationServices,ICommonServices  commonServices, IBookRidesRepository bookRidesRepository)
        {
            this.offerRideRepository = offerRideRepository;
            this.locationServices = locationServices;
            this.commonServices = commonServices;
            this.bookRidesRepository= bookRidesRepository;
        }
        
        public List<RideCard>? GetMatchedRide(string source, string destination, DateOnly date, int time, Guid userId)
        {
            int sourceId=locationServices.GetLocationId(source);
            int destinationId = locationServices.GetLocationId(destination);
            if (sourceId == 0 || destinationId == 0)
                return null;

            var x=offerRideRepository.GetMatchedRide(sourceId, destinationId, date, time, userId);

            if (x == null) 
                return null;

            var ridecards = commonServices.CreateRideCard(source, destination, x, null, true);
            return ridecards;
        }
    
        public string BookRide(RideCard rideCard, Guid userId)
        {
            if (offerRideRepository.IsSeatsAvailable(rideCard.Seats, rideCard.Id))
            {
                BookedRide bookedRide = new();
                bookedRide.BookingId = new Guid();
                bookedRide.UserId = userId;
                bookedRide.OfferedRideId = rideCard.Id;
                bookedRide.Source = rideCard.Source;
                bookedRide.Destination = rideCard.Destination;
                bookedRide.BookedSeats = rideCard.Seats;

                return bookRidesRepository.AddBookedRides(bookedRide);
            }
            return "Ride can not be booked";
        }


        public List<RideCard>? GetBookedRides(Guid userId)
        {
            var rides = bookRidesRepository.GetBookedRides(userId);
            if (rides == null) return null;

            var BookedRideCards = commonServices.CreateRideCard("", "", null, rides, false);

            return BookedRideCards;
        }
    }
}

