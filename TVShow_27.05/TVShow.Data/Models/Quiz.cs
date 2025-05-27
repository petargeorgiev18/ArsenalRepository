using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVShow.Data.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Show))]
        public int ShowId { get; set; }
        public Show Show { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<Question> Questions { get; set; } 
            = new List<Question>();
    }
}