using System.ComponentModel.DataAnnotations;

namespace MoneyQuiz.Data.Data.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Question_Text { get; set; } = null!;
        [Required]
        public int Amount { get; set; }
        public ICollection<Answer> Answers { get; set; }
            = new HashSet<Answer>();
        public ICollection<Lifeline> Lifelines { get; set; }
            = new HashSet<Lifeline>();
    }
}
