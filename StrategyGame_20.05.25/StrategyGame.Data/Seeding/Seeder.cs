using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Data.Seeding
{
    public class SeedService
    {
        private readonly StrategyGameDbContext context;
        public SeedService(StrategyGameDbContext context)
        {
            this.context = context;
        }
        public async Task SeedFromJsonAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON файлът не съществува.");
                return;
            }

            var json = await File.ReadAllTextAsync(filePath);
            var data = JsonSerializer.Deserialize<InitialData>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (data == null)
            {
                Console.WriteLine("Неуспешно десериализиране на JSON.");
                return;
            }

            if (!context.Factions.Any())
            {
                await context.Factions.AddRangeAsync(data.Factions);
                await context.SaveChangesAsync();
            }
            if (!context.Resources.Any())
            {
                await context.Resources.AddRangeAsync(data.Resources);
                await context.SaveChangesAsync();
            }
            if (!context.Maps.Any())
            {
                await context.Maps.AddRangeAsync(data.Maps);
                await context.SaveChangesAsync();
            }
            if (!context.Technologies.Any())
            {
                await context.Technologies.AddRangeAsync(data.Technologies);
                await context.SaveChangesAsync();
            }
            if (!context.Buildings.Any())
            {
                await context.Buildings.AddRangeAsync(data.Buildings);
                await context.SaveChangesAsync();
            }
            if (!context.Units.Any())
            {
                await context.Units.AddRangeAsync(data.Units);
                await context.SaveChangesAsync();
            }
            await context.SaveChangesAsync();
            Console.WriteLine("Data successfully seeded!");
        }
    }
}
