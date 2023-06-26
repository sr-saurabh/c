using CarPoolDbContext.CarpoolData;
using CarPoolDbContext.IRepository;
using CarPoolModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolDbContext.Repository
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly CarPoolDataDbContext carPoolDbContext;

        public AuthenticationRepository(CarPoolDataDbContext carPoolDbContext)
        {
            this.carPoolDbContext = carPoolDbContext;
        }

        public User? GetUserByEmail(string email)
        {
            return carPoolDbContext.Users.Where(user => user.Email == email).SingleOrDefault();
        }

        public User? GetUserById(Guid id)
        {
            return carPoolDbContext.Users.Where(user => user.UserId == id).SingleOrDefault();
        }
        public User? ValidateUser(string email, string password)
        {
            return carPoolDbContext.Users.Where(user => user.Email == email && user.Password == password).SingleOrDefault();
            //return carPoolDbContext.Users.Include(obj=> obj.OfferedRides).Where(user => user.Email == email && user.Password == password).SingleOrDefault();
        }

        public void AddUser(User user)
        {
            carPoolDbContext.Users.Add(user);
            carPoolDbContext.SaveChanges();
        }

        public string UpdateUserDetailOrPassword(User user)
        {
            carPoolDbContext.Users.Update(user);
            carPoolDbContext.SaveChanges();
            return "Updated Successfully";
        }

    }
}
