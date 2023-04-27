using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolDbContext.IRepository
{
    public interface ILocationRepository
    {
        List<Location> GetLocation();
        void AddLocation(List<Location> locations);
        int GetSize();
        bool HasLocation(string location);
    }
}
