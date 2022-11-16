using System.Collections.Generic;
using System.Threading.Tasks;

namespace MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Models
{
    public interface IComicModel<T>
    {
        Task<List<T>> GetList(string title);

        Task<List<T>> GetReadList(decimal id);

        Task AddReadList(string comicId, decimal userId);
        Task RemoveReadList(decimal id);
    }
}
