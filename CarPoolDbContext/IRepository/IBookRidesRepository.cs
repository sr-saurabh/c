using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolDbContext.IRepository
{
    public interface IBookRidesRepository
    {
        string AddBookedRides(BookedRide bookedRide);
        List<BookedRide>? GetBookedRides(Guid userId);
    }
}
