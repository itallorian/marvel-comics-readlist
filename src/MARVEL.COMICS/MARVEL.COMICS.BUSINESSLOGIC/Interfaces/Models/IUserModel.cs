using MARVEL.COMICS.BUSINESSLOGIC.Models.User;
using System.Threading.Tasks;

namespace MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Models
{
    public interface IUserModel
    {
        Task<UserOutput> Login(string username, string password);
    }
}
