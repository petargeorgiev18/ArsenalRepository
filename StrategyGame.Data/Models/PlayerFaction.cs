using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Data.Models
{
    public class PlayerFaction
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Faction))]
        public int FactionId { get; set; }
        public Faction Faction { get; set; } = null!;
        [Required]
        public DateTime StartDate { get; set; }
    }
}
