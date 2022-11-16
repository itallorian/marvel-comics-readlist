namespace MARVEL.COMICS.BUSINESSLOGIC.Models
{
    public class Output
    {
        /// <summary>
        /// Informational message for the service consumer.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Property responsible for reporting the success of the request.
        /// </summary>
        public bool Success { get; set; }
    }
}
