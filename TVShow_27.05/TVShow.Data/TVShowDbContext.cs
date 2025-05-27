using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TVShow.Data.Models;

namespace TVShow.Data
{
    public class TVShowDbContext : DbContext
    {
        public TVShowDbContext(DbContextOptions<TVShowDbContext> options)
            : base(options)
        {

        }
        public TVShowDbContext() { }
        public DbSet<Show> Shows { get; set; } = null!;
        public DbSet<Contestant> Contestants { get; set; } = null!;
        public DbSet<Quiz> Quizzes { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<ShowContestant> ShowContestants { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TVShowDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Show>()
                .HasMany(s => s.Quizzes)
                .WithOne(q => q.Show)
                .HasForeignKey(q => q.ShowId);

            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(qq => qq.Quiz)
                .HasForeignKey(qq => qq.QuizId);

            modelBuilder.Entity<Show>()
                .HasMany(s => s.ShowContestants)
                .WithOne(sc => sc.Show)
                .HasForeignKey(sc => sc.ShowId);

            modelBuilder.Entity<ShowContestant>()
                .HasKey(sc => new { sc.ShowId, sc.ContestantId });

            modelBuilder.Entity<ShowContestant>()
                .HasOne(sc => sc.Show)
                .WithMany(s => s.ShowContestants)
                .HasForeignKey(sc => sc.ShowId);

            modelBuilder.Entity<ShowContestant>()
                .HasOne(sc => sc.Contestant)
                .WithMany(c => c.ShowContestants)
                .HasForeignKey(sc => sc.ContestantId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
