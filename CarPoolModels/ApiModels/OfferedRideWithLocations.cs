using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolModels.ApiModels
{
    public class OfferedRideWithLocations
    {
        public OfferedRide OfferedRides { get; set; }
        public List<string>? Locations { get; set; }
    }
}
