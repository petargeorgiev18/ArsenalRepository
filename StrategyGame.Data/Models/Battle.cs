using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Data.Models.Enums;

namespace StrategyGame.Data.Models
{
    public class Battle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Attacker))]
        public int AttackerId { get; set; }
        public Player Attacker { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Defender))]
        public int DefenderId { get; set; }
        public Player Defender { get; set; } = null!;
        [Required]
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime EndedAt { get; set; }
        [Required]
        public BattleResult Result { get; set; }
        [Required]
        public ICollection<BattleUnit> BattleUnits { get; set; }
            = new List<BattleUnit>();
    }
}
