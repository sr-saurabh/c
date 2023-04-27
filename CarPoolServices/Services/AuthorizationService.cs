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
        //private readonly CarPoolDataDbContext carPoolDbContext;
        private readonly IAuthenticationRepository authenticationRepository;

        public AuthorizationServices(IAuthenticationRepository authenticationRepository)
        {
            //this.carPoolDbContext = carPoolDbContext;
            this.authenticationRepository = authenticationRepository;
        }

        public AuthResponse AddUser(string email, string password)
        {
            //var users=carPoolDbContext.Users.Where(user => user.Email == email).ToList();
            var users= authenticationRepository.GetUserByEmail(email);
            if (users!=null)
                return new AuthResponse("", "","Email is already present in the database.");

            Guid id = Guid.NewGuid();
            string name = email.Split('@')[0];

            User newUser=new User { Email= email, Password = password,UserId=id,UserName=name,Image= "assets/imageNotAdded.jpg" };

            authenticationRepository.AddUser(newUser);
            //carPoolDbContext.Users.Add(newUser);
            //carPoolDbContext.SaveChanges();

            var token = GenerateJwtToken(newUser);
            return new AuthResponse(newUser.Image, token, "Signup Successful");
        }

        public AuthResponse AuthenticateUser(string email, string password)
        {
            //var users = carPoolDbContext.Users.Where(user => user.Email == email).ToList();
            var user = authenticationRepository.GetUserByEmail(email);

            if (user==null)
                return new AuthResponse("", "", "Email not found, please signUp first.");

            user = authenticationRepository.ValidateUser(email,password);
            //users = carPoolDbContext.Users.Where(user => user.Email == email && user.Password == password).ToList();

            if (user==null)
                return new AuthResponse("", "", "Email or password incorrect.");

            var token = GenerateJwtToken(user);
            return new AuthResponse(user.Image, token, "Login Successful");
        }

        public string UpdatePassword(Guid userId, string newPassword, string oldPassword )
        {
            var user= authenticationRepository.GetUserById(userId);
            if (user == null)
                return "User not found!";
            if (user.Password != oldPassword)
                return "Password does not match!, Please Try Again..";
            user.Password = newPassword;

            return authenticationRepository.UpdateUserDetailOrPassword(user);
        }
        public string UpdateUserDetail(Guid userId,string name, string image)
        {
            var user = authenticationRepository.GetUserById(userId);
            if (user == null)
                return "User not found!";
            user.UserName = name;
            user.Image = image;
            return authenticationRepository.UpdateUserDetailOrPassword(user);
        }


        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 60 minutes
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Super-Secret_Car-Pool-User"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Id", user.UserId.ToString()),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var tokenDescriptor = new JwtSecurityToken(
                issuer: "https://localhost:7221",
                audience: "https://localhost:7221",
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);


        }
    }
}

