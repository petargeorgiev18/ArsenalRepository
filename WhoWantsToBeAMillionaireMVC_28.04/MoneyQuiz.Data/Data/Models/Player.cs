using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        public ICollection<Player_Game_Session> Player_Game_Sessions { get; set; }
            = new HashSet<Player_Game_Session>();
    }
}
