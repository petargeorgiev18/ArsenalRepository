using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data.Data.Models
{
    public class Player_Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Player_Game_Session))]
        public int Player_Session_Id { get; set; }
        public Player_Game_Session Player_Game_Session { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Answer))]
        public int Answer_Id { get; set; }
        public Answer Answer { get; set; } = null!;
        [Required]
        public bool Is_Correct { get; set; }
    }
}
