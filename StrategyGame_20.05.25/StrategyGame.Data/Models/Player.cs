using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Data.Models
{
    public class Player
    {
        [Key]   
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public DateTime CreatedAt { get; set; }
        public ICollection<PlayerFaction> PlayerFactions { get; set; } 
            = new List<PlayerFaction>();
        public ICollection<PlayerBuilding> PlayerBuildings { get; set; } 
            = new List<PlayerBuilding>();
        public ICollection<PlayerUnit> PlayerUnits { get; set; } 
            = new List<PlayerUnit>();
        public ICollection<PlayerResource> PlayerResources { get; set; } 
            = new List<PlayerResource>();
        public ICollection<PlayerTechnology> PlayerTechnologies { get; set; } 
            = new List<PlayerTechnology>();
        public ICollection<PlayerLocation> PlayerLocations { get; set; } 
            = new List<PlayerLocation>();
        public ICollection<BattleUnit> BattleUnits { get; set; } 
            = new List<BattleUnit>();
    }
}
