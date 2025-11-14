using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesData.Entities
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string BirthCountry { get; set; } = null!;
        public int BirthYear { get; set; }
        [Required]
        public string ImageUrl { get; set; } = null!;
    }
}
