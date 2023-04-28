using CarPoolDbContext.IRepository;
using CarPoolDbContext.Repository;
using CarPoolModels.Models;
using CarPoolServices.IContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolServices.Services
{
    public class LocationServices: ILocationServices
    {
        private readonly ILocationRepository locationRepository;

        public LocationServices(ILocationRepository locationRepository)
        {
            this.locationRepository= locationRepository;
        }

        public List<Location> GetLocations()
        {
            return locationRepository.GetLocation();
        }

        public int GetLocationId(string location) {

            return locationRepository.GetLocationId(location);
        }

        public void AddLocations(List<string> locations)
        {
            int size = locationRepository.GetSize();
            locationRepository.AddLocation(CreateList(locations, size));
        }

        private List<Location> CreateList(List<string> locations, int size)
        {
            List<Location> loc = new();
            for(int i=0;i< locations.Count; i++)
            {

                string tempLocation = locations[i].ToLower();
                if (!locationRepository.HasLocation(tempLocation))
                {
                    Location location = new() {LocationName = tempLocation };
                    loc.Add(location);
                }
            }
            return loc;

        }
    }
}
