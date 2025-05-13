using Luxor.Data;
using Luxor.Data.Seeding;
using Luxor.View;

namespace Luxor
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using LuxorDbContext context = new LuxorDbContext();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            DataSeeder seeder = new DataSeeder();
            Console.WriteLine(await seeder.SeedRoomTypes(context));
            Console.WriteLine(await seeder.SeedRooms(context));
            Console.WriteLine(await seeder.SeedGuests(context));
            Console.WriteLine(await seeder.SeedEmployees(context));
            Console.WriteLine(await seeder.SeedServices(context));
            Console.WriteLine(await seeder.SeedBookings(context));
            Console.WriteLine(await seeder.SeedBookingServices(context));
            Console.WriteLine(await seeder.SeedEmployeeServices(context));
            Console.WriteLine(await seeder.SeedFeedbacks(context));
            Display display = new Display(context);
            await display.ShowAdminMenu();
            //await display.ShowGuestMenu();
        }
    }
}
