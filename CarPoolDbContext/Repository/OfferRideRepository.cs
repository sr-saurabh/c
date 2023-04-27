using CarPoolDbContext.CarpoolData;
using CarPoolDbContext.IRepository;
using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolDbContext.Repository
{
    public class OfferRideRepository: IOfferRideRepository
    {
        private readonly CarPoolDataDbContext carPoolDbContext;

        public OfferRideRepository(CarPoolDataDbContext carPoolDbContext)
        {
            this.carPoolDbContext = carPoolDbContext;
        }

        public string AddOfferedRide(OfferedRide ride)
        {
            carPoolDbContext.OfferedRides.Add(ride);
            carPoolDbContext.SaveChanges();

            return "Offered ride added successfully";
        }

        public void GetOfferedRide()
        {

        }
    }
}
