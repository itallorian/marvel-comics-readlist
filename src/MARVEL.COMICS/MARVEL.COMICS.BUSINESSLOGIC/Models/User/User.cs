using System.ComponentModel.DataAnnotations;

namespace MARVEL.COMICS.BUSINESSLOGIC.Models.User
{
    public class User : Login
    {
        public decimal Id { get; set; }

        public bool Active { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(255, ErrorMessage = "{0} require max 255 characters.")]
        [MinLength(3, ErrorMessage = "{0} require min 3 characters.")]
        public string Name { get; set; }
    }
}
