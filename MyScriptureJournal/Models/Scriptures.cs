using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scriptures
    {

        public int Id { get; set; }

        [Required]
        public string? Book { get; set; }


        [Required]
        public int Chapter { get; set; }


        [Required]
        public int Verse { get; set; }


        [Required]
        public string? Note { get; set; }


        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        
        
    }
}
