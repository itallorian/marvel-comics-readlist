using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Token;
using MARVEL.COMICS.REPOSITORY.Context;
using MARVEL.COMICS.REPOSITORY.Models;
using System;
using System.Linq;

namespace MARVEL.COMICS.REPOSITORY.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ComicsContext _context;

        public ApplicationRepository()
        {
            _context = new ComicsContext();
        }

        /// <summary>
        /// Method of obtaining an application.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public Application GetApplication(Application application)
        {
            try
            {
                var result = (from app in _context.Set<APPLICATIONS>()
                              where app.ID == application.Id
                              && app.SECRET.Equals(application.Secret)
                              select new Application
                              {
                                  Id = app.ID,
                                  Secret = app.SECRET
                              }).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
