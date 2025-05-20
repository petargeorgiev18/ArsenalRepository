using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StrategyGame.Data.Models
{
    public class PlayerLocation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Map))]
        public int MapId { get; set; }
        public Map Map { get; set; } = null!;
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
    }
}