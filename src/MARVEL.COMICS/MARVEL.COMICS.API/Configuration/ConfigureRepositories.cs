using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories;
using MARVEL.COMICS.REPOSITORY.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MARVEL.COMICS.API.Configuration
{
    public class ConfigureRepositories
    {
        public void AddScoped(IServiceCollection service)
        {
            service.AddScoped<IApplicationRepository, ApplicationRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IReadingListRepository, ReadingListRepository>();
        }
    }
}
