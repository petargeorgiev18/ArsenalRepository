using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AuthorsBooksEFCore.Data.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string First_Name { get; set; } = null!;
        [Required]
        public string Last_Name { get; set; } = null!;
        [Required]
        public string Nationality { get; set; } = null!;
        public ICollection<Book> Books { get; set; }
            = new HashSet<Book>();
    }
}
