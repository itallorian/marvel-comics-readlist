using System.ComponentModel.DataAnnotations;

namespace MARVEL.COMICS.BUSINESSLOGIC.Models.User
{
    public class Login
    {
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(30, ErrorMessage = "{0} require max 30 characters.")]
        [MinLength(3, ErrorMessage = "{0} require min 30 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(512, ErrorMessage = "{0} require max 512 characters.")]
        [MinLength(8, ErrorMessage = "{0} require min 8 characters.")]
        public string Password { get; set; }
    }
}
