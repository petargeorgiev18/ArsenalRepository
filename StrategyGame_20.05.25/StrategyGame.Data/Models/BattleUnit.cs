using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Data.Models
{
    public class BattleUnit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Battle))]
        public int BattleId { get; set; }
        public Battle Battle { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }
        public Unit Unit { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
    }
}
