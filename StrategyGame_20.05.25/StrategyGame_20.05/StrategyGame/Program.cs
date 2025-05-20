using StrategyGame.Core.Services;
using StrategyGame.Data;
using StrategyGame.Data.Seeding;

namespace StrategyGame
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using StrategyGameDbContext context = new StrategyGameDbContext();
            GameService service = new GameService(context);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            SeedService seeder = new SeedService(context);
            string filePath = Path.Combine(Environment.CurrentDirectory, "Dataset", "data.json");
            await seeder.SeedFromJsonAsync(filePath);
            while (true)
            {
                Console.WriteLine("=== Game Menu ===");
                Console.WriteLine("1. Покажи всички играчи с ресурси");
                Console.WriteLine("2. Покажи последните 5 битки");
                Console.WriteLine("3. Покажи сгради и единици за фракция");
                Console.WriteLine("0. Изход");
                Console.Write("Избор: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await service.GetPlayersWithResourcesAsync();
                        break;

                    case "2":
                        await service.GetLastFiveBattlesAsync();
                        break;

                    case "3":
                        Console.Write("Въведи име на фракция: ");
                        string faction = Console.ReadLine()!;
                        var data = await service.GetBuildingsAndUnitsForFactionAsync(faction);
                        if (data.Count == 0)
                        {
                            Console.WriteLine("Няма намерени сгради или единици за тази фракция.");
                        }
                        else
                        {
                            Console.WriteLine($"Сгради и единици за фракция '{faction}':");
                            foreach (var item in data)
                            {
                                var typeProp = item.GetType().GetProperty("Type");
                                var nameProp = item.GetType().GetProperty("Name");

                                var type = typeProp?.GetValue(item)?.ToString();
                                var name = nameProp?.GetValue(item)?.ToString();

                                Console.WriteLine($"{type}: {name}");
                            }
                        }
                        break;

                    case "0":
                        Console.WriteLine("Изход...");
                        return;

                    default:
                        Console.WriteLine("Невалиден избор. Опитай пак.");
                        break;
                }
            }
        }
    }
}
