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
    public class LocationRepository: ILocationRepository
    {
        private readonly CarPoolDataDbContext carPoolDbContext;

        public LocationRepository(CarPoolDataDbContext carPoolDbContext)
        {
            this.carPoolDbContext = carPoolDbContext;
        }

        public void AddLocation(List<Location> locations)
        {

            carPoolDbContext.Locations.AddRange(locations);
            carPoolDbContext.SaveChanges();

        }
        public int GetSize()
        {
            return carPoolDbContext.Locations.Count();
        }
        public List<Location> GetLocation()
        {
            return carPoolDbContext.Locations.ToList();
        }

        public bool HasLocation(string location)
        {
            if (carPoolDbContext.Locations.Where(loc=>loc.LocationName==location.ToLower()).Count()==0)
                return false;
            return true;
        }
        public int GetLocationId(string location) 
        {
            var x = carPoolDbContext.Locations.Where(loc => loc.LocationName == location);
            if(!x.Any()) 
                return 0;

            return x.First().LocationId;
        }
    }
}
