using Microsoft.EntityFrameworkCore;
using StrategyGame.Data;
using StrategyGame.Data.Models;

namespace StrategyGame.Core.Services
{
    public class GameService
    {
        private readonly StrategyGameDbContext context;
        public GameService(StrategyGameDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Player>> GetPlayersWithResourcesAsync()
        {
            return await context.Players.ToListAsync();
        }
        public async Task<List<Battle>> GetLastFiveBattlesAsync()
        {
            return await context.Battles
                .OrderByDescending(b => b.EndedAt)
                .Take(5)
                .ToListAsync();
        }
        public async Task<List<object>> GetBuildingsAndUnitsForFactionAsync(string faction)
        {
            var buildings = context.Buildings
                .Where(b => b.Faction.Name == faction)
                .Select(b => new
                {
                    Type = "Building",
                    b.Name
                });

            var units = context.Units
                .Where(u => u.Faction.Name == faction)
                .Select(u => new
                {
                    Type = "Unit",
                    u.Name
                });
            var result = await buildings.Union<object>(units).ToListAsync();
            return result;
        }
    }
}
