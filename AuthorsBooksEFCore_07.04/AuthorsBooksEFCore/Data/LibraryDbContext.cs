using AuthorsBooksEFCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using static AuthorsBooksEFCore.Data.Connection;

namespace AuthorsBooksEFCore.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base() { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection.conString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
