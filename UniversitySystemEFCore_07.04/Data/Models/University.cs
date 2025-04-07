using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystemEFCore.Data.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public ICollection<Faculty> Faculties { get; set; }
            = new HashSet<Faculty>();
    }
}
