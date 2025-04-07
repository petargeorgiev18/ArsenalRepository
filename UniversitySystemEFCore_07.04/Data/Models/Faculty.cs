using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystemEFCore.Data.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(University))]
        public int UniversityId { get; set; }
        public virtual University University { get; set; } = null!;
        public virtual ICollection<Major> Majors { get; set; } 
            = new HashSet<Major>();
    }
}
