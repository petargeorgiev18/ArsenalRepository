using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorsBooksEFCore.Data.Models
{
    public class Book
    {
        [Key] 
        public int ID { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Author))]
        public int AutorId { get; set; }
        public Author Author { get; set; } = null!;
        [Required]
        public string Publisher { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
    }
}
