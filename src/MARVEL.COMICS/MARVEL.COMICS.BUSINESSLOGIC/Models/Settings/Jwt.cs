namespace MARVEL.COMICS.BUSINESSLOGIC.Models.Settings
{
    public class Jwt
    {
        /// <summary>
        /// Token issuer.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Token audience.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Token key.
        /// </summary>
        public string Key { get; set; }
    }
}
