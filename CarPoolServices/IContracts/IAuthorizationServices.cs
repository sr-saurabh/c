using CarPoolModels.ApiModels;
using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolServices.IContracts
{
    public interface IAuthorizationServices
    {
        public AuthResponse AddUser(string email, string password);
        public AuthResponse AuthenticateUser(string email, string password);
        Response UpdateUserDetail(Guid userId, string name, string image);
        Response UpdatePassword(Guid userId, string newPassword, string oldPassword);
    }
}
