using MARVEL.COMICS.BUSINESSLOGIC.Constants;
using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MARVEL.COMICS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        /// <summary>
        /// Default output object of the Token Controller.
        /// </summary>
        private TokenOutput _output;

        /// <summary>
        /// Property to return status code.
        /// </summary>
        private HttpStatusCode _httpStatusCode;

        /// <summary>
        /// Token Controller management service.
        /// </summary>
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Token Controller Builder.
        /// </summary>
        /// <param name="tokenService"></param>
        public TokenController(ITokenService tokenService)
        {
            _output = new TokenOutput();

            _tokenService = tokenService;
        }

        /// <summary>
        /// Endpoint responsible for generating a token and making available to the 
        /// application of use, when authorized.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GenerateToken([FromBody] Application application)
        {
            try
            {
                _output = await _tokenService.ProccessTokenGeneration(application);

                _httpStatusCode = _output.Success ? HttpStatusCode.Created : HttpStatusCode.Unauthorized;
            }
            catch (Exception)
            {
                _httpStatusCode = HttpStatusCode.InternalServerError;
                _output.Message = Messages.InternalErrorWithoutTreatment;
            }

            return StatusCode(_httpStatusCode.GetHashCode(), _output);
        }

        /// <summary>
        /// Endpoint responsible for validate token.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("validate")]
        public IActionResult ValidateToken()
        {
            _httpStatusCode = HttpStatusCode.NoContent;

            return StatusCode(_httpStatusCode.GetHashCode());
        }
    }
}
