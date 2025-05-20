using StrategyGame.Data;
using StrategyGame.Data.Seeding;

namespace StrategyGame_20._05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using StrategyGameDbContext strategyGameDbContext = new StrategyGameDbContext();
            strategyGameDbContext.Database.EnsureDeleted();
            strategyGameDbContext.Database.EnsureCreated();
            Seeder.Seed();
            Console.WriteLine("Database successfully seeded with initial data.");
        }
    }
}
