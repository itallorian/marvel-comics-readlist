using MARVEL.COMICS.BUSINESSLOGIC.Models.Token;

namespace MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories
{
    public interface IApplicationRepository
    {
        /// <summary>
        /// Method in interface of obtaining an application.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        Application GetApplication(Application application);
    }
}
