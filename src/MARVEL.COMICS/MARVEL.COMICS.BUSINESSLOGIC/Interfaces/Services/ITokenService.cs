using MARVEL.COMICS.BUSINESSLOGIC.Models.Token;
using System.Threading.Tasks;

namespace MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services
{
    public interface ITokenService
    {
        Task<TokenOutput> ProccessTokenGeneration(Application application);
    }
}
