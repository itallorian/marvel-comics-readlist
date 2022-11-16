using MARVEL.COMICS.BUSINESSLOGIC.Constants;
using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories;
using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Settings;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Token;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MARVEL.COMICS.API.Services
{
    public class TokenService : ITokenService
    {
        /// <summary>
        /// Global class of settings loaded at the start of the application.
        /// </summary>
        private readonly AppSettings _settings;

        /// <summary>
        /// Application data access repository.
        /// </summary>
        private readonly IApplicationRepository _applicationRepository;

        /// <summary>
        /// Token service builder, responsible for instantiating the settings class and repositories.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="applicationRepository"></param>
        public TokenService(AppSettings settings, IApplicationRepository applicationRepository)
        {
            _settings = settings;
            _applicationRepository = applicationRepository;
        }

        /// <summary>
        /// Method responsible for processing token generation and handling in case of failure.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public async Task<TokenOutput> ProccessTokenGeneration(Application application)
        {
            if (_applicationRepository.GetApplication(application) != null)
            {
                return await GenerateToken(application.Secret);
            }

            return new TokenOutput { Message = string.Format(Messages.FailedInTokenGeneration, "application without access") };
        }

        /// <summary>
        /// Method responsible for generating a new token for the application.
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        internal async Task<TokenOutput> GenerateToken(string secret)
        {
            var expires = DateTime.UtcNow.AddHours(24);
            var key = Encoding.ASCII.GetBytes(_settings.Jwt.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, secret),
                new Claim(JwtRegisteredClaimNames.Email, secret),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             }),
                Expires = expires,
                Issuer = _settings.Jwt.Issuer,
                Audience = _settings.Jwt.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            await Task.CompletedTask;

            return new TokenOutput
            {
                Token = jwtToken,
                ExpirationTime = expires,
                Message = Messages.SuccessInTokenGeneration,
                Success = true
            };
        }
    }
}
