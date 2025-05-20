using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StrategyGame.Data.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public int BuildTime { get; set; }
        [Required]
        [ForeignKey(nameof(Faction))]
        public int FactionId { get; set; }
        public Faction Faction { get; set; } = null!;
        public ICollection<PlayerBuilding> PlayerBuildings { get; set; } 
            = new List<PlayerBuilding>();
    }
}