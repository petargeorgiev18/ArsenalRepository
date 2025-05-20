using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StrategyGame.Data.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int AttackPower { get; set; }
        [Required]
        public int DefensePower { get; set; }
        [Required]
        public int TrainingTime { get; set; }
        [Required]
        [ForeignKey(nameof(Faction))]
        public int FactionId { get; set; }
        public Faction Faction { get; set; } = null!;
        public ICollection<PlayerUnit> PlayerUnits { get; set; } 
            = new List<PlayerUnit>();
    }

}