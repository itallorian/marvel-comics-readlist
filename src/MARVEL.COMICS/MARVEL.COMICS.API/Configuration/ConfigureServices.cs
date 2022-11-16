using MARVEL.COMICS.API.Services;
using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MARVEL.COMICS.API.Configuration
{
    public class ConfigureServices
    {
        public void AddScoped(IServiceCollection service)
        {
            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IComicService, ComicService>();
        }
    }
}
