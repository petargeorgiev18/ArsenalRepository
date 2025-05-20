using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Data.Models
{
    public class Faction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public ICollection<Building> Buildings { get; set; } 
            = new List<Building>();
        public ICollection<Unit> Units { get; set; } = new List<Unit>();
        public ICollection<PlayerFaction> PlayerFactions { get; set; } 
            = new List<PlayerFaction>();
    }

}
