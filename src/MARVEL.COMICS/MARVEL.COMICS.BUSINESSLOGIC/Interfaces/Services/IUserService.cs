using MARVEL.COMICS.BUSINESSLOGIC.Models.User;
using System.Threading.Tasks;

namespace MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> AddUser(User user);

        Task<bool> UpdateUser(User user);

        Task<User> Login(string username, string password);
    }
}
