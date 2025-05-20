using System.Text.Json;

namespace StrategyGame.Data.Seeding
{
    public class Seeder
    {
        public static void Seed()
        {
            var json = File.ReadAllText("../../../data.json");
            var initialData = JsonSerializer.Deserialize<InitialData>(json);

            using (var context = new StrategyGameDbContext())
            {
                context.Factions.AddRange(initialData.Factions);
                context.Buildings.AddRange(initialData.Buildings);
                context.Units.AddRange(initialData.Units);
                context.Resources.AddRange(initialData.Resources);
                context.Technologies.AddRange(initialData.Technologies);
                context.Maps.AddRange(initialData.Maps);

                context.SaveChanges();
            }
        }
    }
}
