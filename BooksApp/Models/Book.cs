using System.ComponentModel.DataAnnotations;

namespace BooksApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string BookTitle { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [Required]
        [Range(1900,2023)]
        public int RealeseYear { get; set; }
        [Required]
        [Range(0, 10000)]
        public int Pages { get; set; }

    }
}
