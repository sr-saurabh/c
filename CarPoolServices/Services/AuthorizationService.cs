using CarPoolDbContext.CarpoolData;
using CarPoolDbContext.IRepository;
using CarPoolDbContext.Repository;
using CarPoolModels.ApiModels;
using CarPoolModels.Models;
using CarPoolServices.IContracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolServices.Services
{
    public class AuthorizationServices:IAuthorizationServices
    {
        private readonly IAuthenticationRepository authenticationRepository;

        public AuthorizationServices(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }

        public AuthResponse AddUser(string email, string password)
        {
            var users= authenticationRepository.GetUserByEmail(email);
            if (users!=null)
                return new AuthResponse("", "", "", "", "Email is already present in the database.");

            Guid id = Guid.NewGuid();
            string name = "User";

            User newUser=new() { Email= email, Password = password,UserId=id,UserName=name,Image= "../../../assets/imageNotAdded.jpg" };

            authenticationRepository.AddUser(newUser);

            var token = GenerateJwtToken(newUser);
            return new AuthResponse(newUser.Image, newUser.UserName, newUser.Email, token, "Signup Successful");
        }

        public AuthResponse AuthenticateUser(string email, string password)
        {
            var user = authenticationRepository.GetUserByEmail(email);

            if (user==null)
                return new AuthResponse("", "","","", "Email not found, please signUp first.");

            user = authenticationRepository.ValidateUser(email,password);

            if (user==null)
                return new AuthResponse("", "", "", "", "Email or password incorrect.");

            var token = GenerateJwtToken(user);
            return new AuthResponse(user.Image,user.UserName,user.Email, token, "Login Successful");
        }

        public Response UpdatePassword(Guid userId, string newPassword, string oldPassword )
        {
            var user= authenticationRepository.GetUserById(userId);
            if (user == null)
                return new() { ResponseMessage = "User not found!" };
            
            if (user.Password != oldPassword)
                return new() { ResponseMessage = "Password does not match!, Please Try Again.." };
            user.Password = newPassword;
            var x= authenticationRepository.UpdateUserDetailOrPassword(user);
            return new() { ResponseMessage = x };

        }
        public Response UpdateUserDetail(Guid userId,string name, string image)
        {
            var user = authenticationRepository.GetUserById(userId);
            if (user == null)
                return new() { ResponseMessage = "User not found!" };
            user.UserName = name;
            user.Image = image;
            var x=authenticationRepository.UpdateUserDetailOrPassword(user);
            
            return new() { ResponseMessage =x };
        }


        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 60 minutes
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Super-Secret_Car-Pool-User"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var authClaims = new List<Claim>
            {
                new Claim("Id", user.UserId.ToString()),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var tokenDescriptor = new JwtSecurityToken(
                issuer: "https://localhost:7221",
                audience: "https://localhost:7221",
                claims: authClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);


        }
    }
}

