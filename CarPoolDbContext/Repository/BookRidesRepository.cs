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
    public class BookRidesRepository: IBookRidesRepository
    {
        private readonly CarPoolDataDbContext carPoolDbContext;
        public BookRidesRepository(CarPoolDataDbContext carPoolDbContext)
        {
            this.carPoolDbContext = carPoolDbContext;
        }
        public string AddBookedRides(BookedRide bookedRide)
        {
            try {}
            catch(Exception ex) { }
            carPoolDbContext.BookedRides.Add(bookedRide);   
            return "Ride booked successfully";
        }
        public List<BookedRide>? GetBookedRides(Guid userId)
        {
            var bookedRides= carPoolDbContext.BookedRides.Where(ride=>ride.UserId == userId).ToList();
            return bookedRides;
        }
    }
}
