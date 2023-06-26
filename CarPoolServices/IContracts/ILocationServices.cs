using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolServices.IContracts
{
    public interface ILocationServices
    {
        void AddLocations(List<string> locations);
        List<Location> GetLocations();
        int GetLocationId(string location);
    }
}
