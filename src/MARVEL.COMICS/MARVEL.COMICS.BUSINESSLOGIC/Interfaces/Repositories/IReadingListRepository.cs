using MARVEL.COMICS.BUSINESSLOGIC.Models.Comics;
using System.Collections.Generic;

namespace MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories
{
    public interface IReadingListRepository
    {
        void AddReadingList(string comicId, decimal userId);

        void MarkAsRead(decimal id);

        void RemoveFromReadingList(decimal id);

        List<ReadingList> GetAll(decimal userId);
    }
}
