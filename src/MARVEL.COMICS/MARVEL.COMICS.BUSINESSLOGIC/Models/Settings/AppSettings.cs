using MARVEL.COMICS.BUSINESSLOGIC.Models.Token;

namespace MARVEL.COMICS.BUSINESSLOGIC.Models.Settings
{
    public class AppSettings
    {
        /// <summary>
        /// Configuration keys for generation and consumption of the authentication token.
        /// </summary>
        public Jwt Jwt { get; set; }

        public Application Application { get; set; }

        public Endpoint Endpoint { get; set; }

        public Marvel Marvel { get; set; }
    }
}
