using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Data.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        public ICollection<PlayerLocation> PlayersLocations { get; set; }
            = new List<PlayerLocation>();
    }
}
