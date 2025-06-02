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
        public List<Faction> Factions { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Unit> Units { get; set; }
        public List<Resource> Resources { get; set; }
        public List<Technology> Technologies { get; set; }
        public List<Map> Maps { get; set; }
    }

}
