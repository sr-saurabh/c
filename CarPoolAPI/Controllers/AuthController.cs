using CarPoolModels.Models;
using CarPoolServices.IContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CarPoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthController : Controller
    {
        private readonly IAuthorizationServices authorizationServices;
        public AuthController(IAuthorizationServices authorizationServices)
        {
            this.authorizationServices = authorizationServices;
        }

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {
            var response=authorizationServices.AuthenticateUser(email, password);
            if (response.Token == "")
                return BadRequest(response.Message);
            return Ok(response);
        }

        [HttpGet]
        [Route("signUp")]
        [AllowAnonymous]
        public IActionResult Signup(string email, string password)
        {
            var response=authorizationServices.AddUser(email, password);
            if (response.Token == "")
                return BadRequest(response.Message);
            return Ok(response);
        }



        [HttpPost]
        [Route("update-user-details")]
        public IActionResult ChangeUserDetails(string name, string image)
        {
            try
            {
                if (User.FindFirst("Id") == null)
                    throw new Exception();
                if (name == "" || image == "")
                    return BadRequest("Please Fill all the details");

                var id=new Guid(User.FindFirst("Id").Value);

                return Ok(authorizationServices.UpdateUserDetail(id, name, image));

            }
            catch { return BadRequest("Please Login First"); }
        }



        [HttpPost]
        [Route("change-password")]
        public IActionResult ChangePassword(string newPassword, string oldPassword)
        {
            try
            {
                if (User.FindFirst("Id")==null)
                    throw new Exception();
                if(newPassword=="" || oldPassword=="")
                    return BadRequest("Please Fill all the details");

                var id = new Guid(User.FindFirst("Id").Value);

                return Ok(authorizationServices.UpdatePassword(id, newPassword, oldPassword));
            }
            catch { return BadRequest("Please Login First"); }
        }
    }
}
