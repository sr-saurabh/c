using Azure.Core;
using CarPoolDbContext.CarpoolData;
using CarPoolDbContext.IRepository;
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

        //private readonly CarPoolDataDbContext carPoolDataDbContext; 
        //private readonly DbContext context;

        //public OfferRideServices(CarPoolDataDbContext carPoolDataDbContext,DbContext context)
        //public OfferRideServices(CarPoolDataDbContext carPoolDataDbContext, IOfferRideRepository offerRideRepository) 
        
        public OfferRideServices(IOfferRideRepository offerRideRepository, ILocationServices locationServices) 
        {
            this.offerRideRepository = offerRideRepository;
            this.locationServices = locationServices;
            //this.carPoolDataDbContext = carPoolDataDbContext;
            //this.context = context;
        }

        public string AddOfferedRide(OfferedRideWithLocations ride)
        {
            if (ride.OfferedRides == null)
                return "Please fill all details";

            List<string> locations = new();
            if (ride.Locations!=null)
                locations=ride.Locations;

            locations.Add(ride.OfferedRides.OfferingTo);
            locations.Add(ride.OfferedRides.OfferingFrom);

            locationServices.AddLocations(locations);

            return offerRideRepository.AddOfferedRide(ride.OfferedRides);
        }
    }
}

