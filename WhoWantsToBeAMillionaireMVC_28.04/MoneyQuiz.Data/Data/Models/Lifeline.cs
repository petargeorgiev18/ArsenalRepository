using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data.Data.Models
{
    public class Lifeline
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Player_Game_Session))]
        public int Player_Game_Session_Id { get; set; }
        public Player_Game_Session Player_Game_Session { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Question))]
        public int Used_On_Question_Id { get; set; }
        public Question Question { get; set; } = null!;
    }
}
