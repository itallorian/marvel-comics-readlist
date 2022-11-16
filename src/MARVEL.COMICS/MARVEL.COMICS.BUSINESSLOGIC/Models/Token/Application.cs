namespace MARVEL.COMICS.BUSINESSLOGIC.Models.Token
{
    public class Application
    {
        /// <summary>
        /// Identification of the application in the database.
        /// </summary>
        public decimal Id { get; set; }

        /// <summary>
        /// Application secret token, used in token generation.
        /// </summary>
        public string Secret { get; set; }
    }
}
