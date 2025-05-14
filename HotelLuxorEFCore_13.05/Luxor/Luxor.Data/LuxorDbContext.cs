using Luxor.Data.Models;
using Microsoft.EntityFrameworkCore;
using static Luxor.Data.Configuration.Connection;

namespace Luxor.Data
{
    public class LuxorDbContext : DbContext
    {
        public LuxorDbContext() { }
        public LuxorDbContext(DbContextOptions<LuxorDbContext> options) : base(options) { }
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<RoomType> RoomTypes { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Guest> Guests { get; set; } = null!;
        public DbSet<EmployeeService> EmployeesServices { get; set; } = null!;
        public DbSet<BookingService> BookingsServices { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
