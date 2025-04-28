using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyQuiz.Data.Data.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Answer_Text { get; set; } = null!;
        [Required]
        public bool Is_Correct { get; set; }
        [Required]
        [ForeignKey(nameof(Question))]
        public int Question_Id { get; set; }
        public Question Question { get; set; } = null!;
        public ICollection<Player_Answer> Player_Answers { get; set; }
            = new HashSet<Player_Answer>();
    }
}