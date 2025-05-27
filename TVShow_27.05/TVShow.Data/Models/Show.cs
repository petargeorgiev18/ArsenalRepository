using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow.Data.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public DateTime? AirDate { get; set; }
        public string? Description { get; set; }
        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public ICollection<ShowContestant> ShowContestants { get; set; } = new List<ShowContestant>();
    }
}
