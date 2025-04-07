using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySystemEFCore.Data.Models
{
    public class Major
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Faculty))]
        public int FacultyId { get; set; }
        [Required]
        public virtual Faculty Faculty { get; set; } = null!;
    }
}