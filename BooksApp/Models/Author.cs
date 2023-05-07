using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksApp.Models
{
    public class Author
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength (20)]
        public string LastName { get; set; }
        [Required]
        [Range (15, 120)]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }
        public  int PublishedBook { get; set; }
    }
}
