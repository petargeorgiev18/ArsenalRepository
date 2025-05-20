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
            using var context = new YourDbContext(); // или използвай DI, ако имаш
            var service = new StrategyGameDbContext(context);

            while (true)
            {
                Console.Clear();
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
                        var players = await service.GetPlayersWithResourcesAsync();
                        Console.WriteLine("\n--- Играчите и ресурсите им ---");
                        foreach (var player in players)
                        {
                            Console.WriteLine($"ID: {player.PlayerID}, Име: {player.PlayerName}, Ресурси: {player.Resources}");
                        }
                        break;

                    case "2":
                        var battles = await service.GetLastFiveBattlesAsync();
                        Console.WriteLine("\n--- Последни 5 битки ---");
                        foreach (var battle in battles)
                        {
                            Console.WriteLine($"BattleID: {battle.BattleID}, Player1: {battle.Player1ID}, Player2: {battle.Player2ID}, Result: {battle.Result}, Date: {battle.BattleDate}");
                        }
                        break;

                    case "3":
                        Console.Write("Въведи име на фракция (напр. Humans): ");
                        var faction = Console.ReadLine();

                        var factionItems = await service.GetBuildingsAndUnitsForFactionAsync(faction);
                        Console.WriteLine($"\n--- Сгради и единици за фракция {faction} ---");
                        foreach (var item in factionItems)
                        {
                            Console.WriteLine($"{item.Type}: {item.Name}");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Изход...");
                        return;

                    default:
                        Console.WriteLine("Невалиден избор. Опитай пак.");
                        break;
                }

                Console.WriteLine("\nНатисни Enter за продължение...");
                Console.ReadLine();
            }
        }
    }
}
