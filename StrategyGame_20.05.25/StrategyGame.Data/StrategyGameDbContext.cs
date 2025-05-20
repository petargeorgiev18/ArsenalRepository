using Microsoft.EntityFrameworkCore;
using StrategyGame.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Data
{
    public class StrategyGameDbContext : DbContext
    {
        public StrategyGameDbContext(DbContextOptions<StrategyGameDbContext> options)
            : base(options) { }
        public StrategyGameDbContext() { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<PlayerFaction> PlayerFactions { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<PlayerBuilding> PlayerBuildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<PlayerUnit> PlayerUnits { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<PlayerResource> PlayerResources { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<BattleUnit> BattleUnits { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<PlayerLocation> PlayerLocations { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<PlayerTechnology> PlayerTechnologies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-VI3C6PQ\\SQLEXPRESS;Database=StrategyGame;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Attacker)
                .WithMany()
                .HasForeignKey(b => b.AttackerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Defender)
                .WithMany()
                .HasForeignKey(b => b.DefenderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
