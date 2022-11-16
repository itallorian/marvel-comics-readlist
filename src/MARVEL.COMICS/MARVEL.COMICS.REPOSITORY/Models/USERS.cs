using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MARVEL.COMICS.REPOSITORY.Models
{
    public class USERS
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        public bool ACTIVE { get; set; }

        public string USERNAME { get; set; }

        public string NAME { get; set; }

        public string PASSWORD { get; set; }
    }
}
