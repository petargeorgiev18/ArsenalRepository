using Microsoft.EntityFrameworkCore;
using UniversitySystemEFCore.Data.Models;
using static UniversitySystemEFCore.Data.Connection;

namespace UniversitySystemEFCore.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext() { }
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<University> Universities { get; set; } = null!;
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
