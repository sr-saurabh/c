using CarPoolModels.ApiModels;
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
        public IActionResult ChangeUserDetails(ChangeUser user)
        {
            try
            {
                if (User.FindFirst("Id") == null)
                    throw new Exception();
                if (user.NewName == "" || user.NewImage == "")
                    return BadRequest("Please Fill all the details");

                var id=new Guid(User.FindFirst("Id").Value);

                return Ok(authorizationServices.UpdateUserDetail(id, user.NewName, user.NewImage));

            }
            catch { return BadRequest("Please Login First"); }
        }



        [HttpPost]
        [Route("change-password")]
        public IActionResult ChangePassword(UpdatePassword updatePassword)
        {
            try
            {
                if (User.FindFirst("Id")==null)
                    throw new Exception();
                if(updatePassword.NewPassword == "" || updatePassword.OldPassword == "")
                    return BadRequest("Please Fill all the details");

                var id = new Guid(User.FindFirst("Id").Value);

                return Ok(authorizationServices.UpdatePassword(id, updatePassword.NewPassword, updatePassword.OldPassword));
            }
            catch { return BadRequest("Please Login First"); }
        }
    }
}
