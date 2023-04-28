using Azure.Core;
using CarPoolDbContext.CarpoolData;
using CarPoolDbContext.IRepository;
using CarPoolDbContext.Repository;
using CarPoolModels.ApiModels;
using CarPoolModels.Models;
using CarPoolServices.IContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolServices.Services
{
    public class OfferRideServices:IOfferRideServices
    {
        private readonly IOfferRideRepository offerRideRepository;
        private readonly ILocationServices locationServices;
        private readonly ICommonServices commonServices;

        public OfferRideServices(IOfferRideRepository offerRideRepository, ILocationServices locationServices, ICommonServices commonServices) 
        {
            this.offerRideRepository = offerRideRepository;
            this.locationServices = locationServices;
            this.commonServices = commonServices;
        }

        public string AddOfferedRide(OfferedRideWithLocations ride)
        {
            if (ride.OfferedRides == null)
                return "Please fill all details";

            List<string> locations = new(){ride.OfferedRides.Source};
            if(ride.Locations!=null)
                locations.AddRange(ride.Locations);
            locations.Add(ride.OfferedRides.Destination);


            locationServices.AddLocations(locations);
            var x= offerRideRepository.AddOfferedRide(ride.OfferedRides);
            AddStoppage(locations, ride.OfferedRides.OfferedRideId);
            return x;
        }

        public List<RideCard>? GetOfferedRides(Guid userId)
        {
            var offeredRides=offerRideRepository.GetOfferedRides(userId);

            if (offeredRides==null || offeredRides.Count()==0)
                return null;
            var offeredRideCards=commonServices.CreateRideCard("", "", offeredRides, null, false);
            return offeredRideCards;
        }

        private void AddStoppage(List<string> locations,Guid offeredRideId)
        {
            List<Stoppage> stoppages= new();
            for (int i = 0; i < locations.Count; i++)
            {

                string tempLocation = locations[i].ToLower();
                int id = locationServices.GetLocationId(tempLocation);
                Stoppage location = new() { OfferedRideId = offeredRideId, StoppageNo = i, LocationId=id };
                stoppages.Add(location);
            }
            offerRideRepository.AddStoppages(stoppages);
        }
    }
}

