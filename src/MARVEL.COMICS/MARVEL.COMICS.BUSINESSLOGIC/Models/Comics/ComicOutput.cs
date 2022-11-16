using System.Collections.Generic;

namespace MARVEL.COMICS.BUSINESSLOGIC.Models.Comics
{
    public class ComicOutput : Output
    {
        public Comic Comic { get; set; }

        public List<ReadingList> ReadingList { get; set; }
    }
}
