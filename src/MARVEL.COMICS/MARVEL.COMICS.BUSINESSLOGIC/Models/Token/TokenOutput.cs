using System;

namespace MARVEL.COMICS.BUSINESSLOGIC.Models.Token
{
    public class TokenOutput : Output
    {
        /// <summary>
        /// Token generated during the request.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Expiration date of the generated token.
        /// </summary>
        public DateTime? ExpirationTime { get; set; }
    }
}
