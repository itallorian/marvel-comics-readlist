namespace MARVEL.COMICS.WEB.ViewModels
{
    public class ComicViewModel
    {
        public ComicViewModel(string id, string title, string description, string thumbnail)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Thumbnail = thumbnail;
        }

        public string Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Thumbnail { get; private set; }

        public decimal? ReadingListId { get; set; }
    }
}
