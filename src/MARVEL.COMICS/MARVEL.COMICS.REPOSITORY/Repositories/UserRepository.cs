using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories;
using MARVEL.COMICS.BUSINESSLOGIC.Models.User;
using MARVEL.COMICS.REPOSITORY.Context;
using MARVEL.COMICS.REPOSITORY.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MARVEL.COMICS.REPOSITORY.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ComicsContext _context;

        public UserRepository()
        {
            _context = new ComicsContext();
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var userModel = new USERS()
                        {
                            ACTIVE = true,
                            USERNAME = user.UserName,
                            NAME = user.Name,
                            PASSWORD = user.Password
                        };

                        await _context.AddAsync(userModel);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        return userModel.ID > 0;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
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
                var user = (from u in _context.Set<USERS>()
                            where 
                                u.USERNAME.ToLower().Equals(username.ToLower())
                                && u.PASSWORD.Equals(password)
                                && u.ACTIVE == true
                            select new User()
                            {
                                Id = u.ID,
                                Active = u.ACTIVE,
                                UserName = u.USERNAME,
                                Name = u.NAME
                            }).FirstOrDefault();

                await Task.CompletedTask;

                return user;
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
                var result = (from u in _context.Set<USERS>()
                              where u.ID == user.Id
                              select u).FirstOrDefault();

                if (result != null)
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            result.ACTIVE = user.Active;
                            result.NAME = user.Name;
                            result.PASSWORD = user.Password;

                            _context.Update(result);
                            await _context.SaveChangesAsync();

                            transaction.Commit();

                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ValidateUserName(string username)
        {
            try
            {
                var user = (from u in _context.Set<USERS>()
                            where 
                                u.USERNAME.ToLower().Equals(username.ToLower())
                                && u.ACTIVE == true
                            select u.ID).FirstOrDefault();

                await Task.CompletedTask;

                return user == 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
