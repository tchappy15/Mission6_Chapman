using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class Application
    {
        //this will becomes a table with our various fields in it

        //Column names:	Category	Title	Year	Director	Rating	Edited	Lent To:	Notes

        [Key]
        [Required]
        public int MovieID { get; set; } //PK. 

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public string Rating { get; set; }

        //these last 3 are not required, so they are nullable
        public bool? Edited { get; set; }

        public string? Lent_To { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
