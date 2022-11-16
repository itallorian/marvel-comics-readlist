using MARVEL.COMICS.BUSINESSLOGIC.Constants;
using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services;
using MARVEL.COMICS.BUSINESSLOGIC.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MARVEL.COMICS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Default output object of the User Controller.
        /// </summary>
        private UserOutput _output;

        /// <summary>
        /// Property to return status code.
        /// </summary>
        private HttpStatusCode _httpStatusCode;

        private readonly IUserService _userService;

        /// <summary>
        /// User Controller Builder.
        /// </summary>
        public UserController(IUserService userService)
        {
            _output = new UserOutput();

            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                var registered = await _userService.AddUser(user);

                _httpStatusCode = registered ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
                _output.Success = registered;
                _output.Message = registered ? Messages.SuccessInUserRegister : Messages.FailedInUserRegister;
            }
            catch (Exception)
            {
                _httpStatusCode = HttpStatusCode.InternalServerError;
                _output.Message = Messages.InternalErrorWithoutTreatment;
            }

            return StatusCode(_httpStatusCode.GetHashCode(), _output);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            try
            {
                var updated = await _userService.UpdateUser(user);

                _httpStatusCode = updated ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
                _output.Success = updated;
                _output.Message = updated ? Messages.SuccessInUserUpdate : Messages.FailedInUserUpdate;
            }
            catch (Exception)
            {
                _httpStatusCode = HttpStatusCode.InternalServerError;
                _output.Message = Messages.InternalErrorWithoutTreatment;
            }

            return StatusCode(_httpStatusCode.GetHashCode(), _output);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login user)
        {
            try
            {
                var userInformations = await _userService.Login(user.UserName, user.Password);

                _httpStatusCode = userInformations != null ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
                _output.Success = userInformations != null;
                _output.User = userInformations;
                _output.Message = userInformations != null ? Messages.SuccessInUserLogin : Messages.FailedInUserLogin;
            }
            catch (Exception)
            {
                _httpStatusCode = HttpStatusCode.InternalServerError;
                _output.Message = Messages.InternalErrorWithoutTreatment;
            }

            return StatusCode(_httpStatusCode.GetHashCode(), _output);
        }
    }
}
