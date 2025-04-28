using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data.Data.Models
{
    public class Game_Session
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public TimeSpan/*int*/ Time { get; set; }
        [Required]
        public int Final_Amount { get; set; }
        public ICollection<Player_Game_Session> Player_Game_Sessions { get; set; }
            = new HashSet<Player_Game_Session>();
    }
}
