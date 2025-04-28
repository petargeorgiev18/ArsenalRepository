using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data.Data
{
    public class MoneyQuizContext : DbContext
    {
        public const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MoneyQuizDb;TrustServerCertificate=True;";
        public MoneyQuizContext() { }
        public MoneyQuizContext(DbContextOptions<MoneyQuizContext> options)
            : base(options)
        {
        }
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Game_Session> Game_Sessions { get; set; } = null!;
        public DbSet<Player_Game_Session> Player_Game_Sessions { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<Lifeline> Lifelines { get; set; } = null!;
        public DbSet<Player_Answer> Player_Answers { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
