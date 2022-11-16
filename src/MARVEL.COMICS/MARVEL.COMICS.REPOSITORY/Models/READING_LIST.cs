using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MARVEL.COMICS.REPOSITORY.Models
{
    public class READING_LIST
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        public bool ACTIVE { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DATE_OF_INSERTION { get; set; }

        public string COMIC_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal USER_ID { get; set; }

        public bool READ { get; set; }
    }
}
