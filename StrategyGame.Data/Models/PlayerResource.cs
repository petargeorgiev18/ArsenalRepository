using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StrategyGame.Data.Models
{
    public class PlayerResource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Resource))]
        public int ResourceId { get; set; }
        public Resource Resource { get; set; } = null!;
        [Required]
        public int Amount { get; set; }
    }
}