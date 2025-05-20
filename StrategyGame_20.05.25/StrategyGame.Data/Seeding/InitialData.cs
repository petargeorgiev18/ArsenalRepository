using StrategyGame.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Data.Seeding
{
    public class InitialData
    {
        public List<Faction> Factions { get; set; } = new List<Faction>();
        public List<Building> Buildings { get; set; } = new List<Building>();
        public List<Unit> Units { get; set; } = new List<Unit>();
        public List<Resource> Resources { get; set; } = new List<Resource>();
        public List<Technology> Technologies { get; set; } = new List<Technology>();
        public List<Map> Maps { get; set; } = new List<Map>();
    }

}
