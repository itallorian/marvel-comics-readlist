using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories;
using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services;
using MARVEL.COMICS.BUSINESSLOGIC.Models.User;
using System;
using System.Threading.Tasks;

namespace MARVEL.COMICS.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                if(await _userRepository.ValidateUserName(user.UserName))
                {
                    return await _userRepository.AddUser(user);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Login(string username, string password)
        {
            try
            {
                return await _userRepository.Login(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                return await _userRepository.UpdateUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
