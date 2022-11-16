using System;

namespace MARVEL.COMICS.BUSINESSLOGIC.Models.Comics
{
    public class ReadingList
    {
        public decimal Id { get; set; }

        public bool Active { get; set; }

        public DateTime DateOfInsertion { get; set; }

        public string ComicId { get; set; }

        public decimal UserId { get; set; }

        public bool Read { get; set; }

        public Comic Comic { get; set; }
    }
}
