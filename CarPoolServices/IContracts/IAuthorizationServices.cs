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
        string UpdateUserDetail(Guid userId, string name, string image);
        string UpdatePassword(Guid userId, string newPassword, string oldPassword);
    }
}
