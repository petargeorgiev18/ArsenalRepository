using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow.Data.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; } = null!;
        [Required]
        public string OptionA { get; set; } = null!;
        [Required]
        public string OptionB { get; set; } = null!;
        [Required]
        public string OptionC { get; set; } = null!;
        [Required]
        public string OptionD { get; set; } = null!;
        [Required]
        [RegularExpression("A|B|C|D", ErrorMessage = "Correct answer must be one of A, B, C, or D.")]
        public string CorrectAnswer { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Quiz))]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;
    }
}
