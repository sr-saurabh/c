using CarPoolModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolModels.ApiModels
{
    public class AuthResponse
    {
        public string Image { get; set;}
        public string Token { get; set;}
        public string Message { get; set;}
        public AuthResponse(string image, string token,string message)
        {
            this.Token = token;
            this.Image = image;
            this.Message = message;
        }

    }
}

