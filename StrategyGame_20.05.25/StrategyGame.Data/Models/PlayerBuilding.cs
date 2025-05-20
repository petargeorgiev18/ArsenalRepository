using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StrategyGame.Data.Models
{
    public class PlayerBuilding
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Building))]
        public int BuildingId { get; set; }
        public Building Building { get; set; } = null!;
        [Required]
        public int Level { get; set; }
        [Required]
        public DateTime BuiltAt { get; set; } = DateTime.UtcNow;
    }
}