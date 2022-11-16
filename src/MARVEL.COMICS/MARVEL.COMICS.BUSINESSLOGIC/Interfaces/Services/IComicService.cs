using MARVEL.COMICS.BUSINESSLOGIC.Models.Comics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services
{
    public interface IComicService
    {
        Task<Comic> ListComics(string title);

        Task AddToReadingList(string comicId, decimal userId);

        Task RemoveFromReadingList(decimal id);

        Task MarkAsRead(decimal id);

        Task<List<ReadingList>> GetAll(decimal userId);
    }
}
