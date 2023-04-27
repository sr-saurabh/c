using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolDbContext.IRepository
{
    public interface IAuthenticationRepository
    {
        User? GetUserByEmail(string email);
        User? ValidateUser(string email, string password);
        void AddUser(User user);
        User? GetUserById(Guid id);

        string UpdateUserDetailOrPassword(User user);
    }
}
