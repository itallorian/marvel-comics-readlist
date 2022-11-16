using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Comics;
using MARVEL.COMICS.REPOSITORY.Context;
using MARVEL.COMICS.REPOSITORY.Models;
using System.Collections.Generic;
using System.Linq;

namespace MARVEL.COMICS.REPOSITORY.Repositories
{
    public class ReadingListRepository : IReadingListRepository
    {
        private readonly ComicsContext _context;

        public ReadingListRepository()
        {
            _context = new ComicsContext();
        }

        public void AddReadingList(string comicId, decimal userId)
        {
            var model = new READING_LIST
            {
                ACTIVE = true,
                COMIC_ID = comicId,
                USER_ID = userId
            };

            _context.Set<READING_LIST>().Add(model);
            _context.SaveChanges();
        }

        public void MarkAsRead(decimal id)
        {
            var result = (from r in _context.Set<READING_LIST>()
                          where r.ID == id
                          select r).FirstOrDefault();

            if(result != null)
            {
                result.READ = true;

                _context.Update(result);
                _context.SaveChanges();
            }
        }

        public void RemoveFromReadingList(decimal id)
        {
            var result = (from r in _context.Set<READING_LIST>()
                          where r.ID == id
                          select r).FirstOrDefault();

            if (result != null)
            {
                result.ACTIVE = false;

                _context.Update(result);
                _context.SaveChanges();
            }
        }

        public List<ReadingList> GetAll(decimal userId)
        {
            var result = (from r in _context.Set<READING_LIST>()
                          where r.USER_ID == userId
                          && r.ACTIVE == true
                          select new ReadingList()
                          {
                              Id = r.ID,
                              Active = r.ACTIVE,
                              ComicId = r.COMIC_ID,
                              DateOfInsertion = r.DATE_OF_INSERTION,
                              Read = r.READ,
                              UserId = r.USER_ID
                          }).ToList();

            return result;
        }
    }
}
