using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data.Data.Models
{
    public class Player_Game_Session
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Player))]
        public int Player_Id { get; set; }
        public Player Player { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(GameSession))]
        public int Session_Id { get; set; }
        public Game_Session GameSession { get; set; } = null!;
        public ICollection<Lifeline> Lifelines { get; set; }
            = new HashSet<Lifeline>();
        public ICollection<Player_Answer> Player_Answers { get; set; }
            = new HashSet<Player_Answer>();
    }
}
