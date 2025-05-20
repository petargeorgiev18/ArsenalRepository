using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StrategyGame.Data.Models
{
    public class PlayerTechnology
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Technology))]
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; } = null!;
        [Required]
        public bool IsResearched { get; set; }
        [Required]
        public DateTime ResearchedAt { get; set; } = DateTime.UtcNow;
    }

}