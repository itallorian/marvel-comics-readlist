using MARVEL.COMICS.BUSINESSLOGIC.Models.User;
using System.Threading.Tasks;

namespace MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);

        Task<bool> UpdateUser(User user);

        Task<User> Login(string username, string password);

        Task<bool> ValidateUserName(string username);
    }
}
