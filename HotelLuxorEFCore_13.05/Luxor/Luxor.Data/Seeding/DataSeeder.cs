using Luxor.Data.Models;
using Luxor.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxor.Data.Seeding
{
    public class DataSeeder
    {
        public async Task<string> SeedBookings(LuxorDbContext context)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Datasets", "booking.txt");
            string[] bookingData = File.ReadAllLines(filePath).Skip(1).ToArray();
            foreach (var line in bookingData)
            {
                string[] data = line.Split(';');
                DateTime accommodationDate = DateTime.ParseExact(data[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime leavingDate = DateTime.ParseExact(data[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime paymentDate = DateTime.ParseExact(data[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Booking booking = new Booking
                {
                    AccommodationDate = accommodationDate,
                    LeavingDate = leavingDate,
                    Amount = decimal.Parse(data[2]),
                    PaymentDate = paymentDate,
                    PaymentMethod = data[4],
                    Status = (Status)Enum.Parse(typeof(Status), data[5]),
                    GuestId = int.Parse(data[6]),
                    RoomId = int.Parse(data[7])
                };
                await context.Bookings.AddAsync(booking);
            }
            await context.SaveChangesAsync();
            sb.AppendLine($"Successfully seeded {bookingData.Length} bookings.");
            return sb.ToString();
        }
        public async Task<string> SeedGuests(LuxorDbContext context)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Datasets", "guest.txt");
            string[] guestData = File.ReadAllLines(filePath).Skip(1).ToArray();
            foreach (var line in guestData)
            {
                string[] data = line.Split(',');
                Guest guest = new Guest
                {
                    FirstName = data[0],
                    LastName = data[1],
                    Email = data[2],
                    PhoneNumber = data[3],
                    Password = data[4]
                };
                await context.Guests.AddAsync(guest);
            }
            await context.SaveChangesAsync();
            sb.AppendLine($"Successfully seeded {guestData.Length} guests.");
            return sb.ToString();
        }
        public async Task<string> SeedBookingServices(LuxorDbContext context)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Datasets", "bookingService.txt");
            string[] bookingServiceData = File.ReadAllLines(filePath).Skip(1).ToArray();
            foreach (var line in bookingServiceData)
            {
                string[] data = line.Split(',');
                BookingService bookingService = new BookingService
                {
                    BookingId = int.Parse(data[0]),
                    ServiceId = int.Parse(data[1])
                };
                await context.BookingsServices.AddAsync(bookingService);
            }
            await context.SaveChangesAsync();
            sb.AppendLine($"Successfully seeded {bookingServiceData.Length} booking services.");
            return sb.ToString();
        }
        public async Task<string> SeedFeedbacks(LuxorDbContext context)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Datasets", "feedback.txt");
            string[] feedbackData = File.ReadAllLines(filePath).Skip(1).ToArray();
            foreach (var line in feedbackData)
            {
                string[] data = line.Split(',');
                DateTime publishedOn = DateTime.ParseExact(data[2], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Feedback feedback = new Feedback
                {
                    Comment = data[0],
                    Rating = int.Parse(data[1]),
                    PublishedOn = publishedOn,
                    BookingId = int.Parse(data[3]),
                    GuestId = int.Parse(data[4])
                };
                await context.Feedbacks.AddAsync(feedback);
            }
            await context.SaveChangesAsync();
            sb.AppendLine($"Successfully seeded {feedbackData.Length} feedbacks.");
            return sb.ToString();
        }
        public async Task<string> SeedRooms(LuxorDbContext context)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Datasets", "room.txt");
            string[] roomData = File.ReadAllLines(filePath).Skip(1).ToArray();
            foreach (var line in roomData)
            {
                string[] data = line.Split(',');
                Room room = new Room
                {
                    RoomNumber = data[0],
                    Description = data[1],
                    Price = decimal.Parse(data[2]),
                    IsAvailable = bool.Parse(data[3]),
                    RoomTypeId = int.Parse(data[4])
                };
                await context.Rooms.AddAsync(room);
            }
            await context.SaveChangesAsync();
            sb.AppendLine($"Successfully seeded {roomData.Length} rooms.");
            return sb.ToString();
        }
        public async Task<string> SeedRoomTypes(LuxorDbContext context)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Datasets", "roomType.txt");
            string[] roomTypeData = File.ReadAllLines(filePath).Skip(1).ToArray();
            foreach (var line in roomTypeData)
            {
                string data = line;
                RoomType roomType = new RoomType
                {
                    Type = (TypeRoom)Enum.Parse(typeof(TypeRoom), data)
                };
                await context.RoomTypes.AddAsync(roomType);
            }
            await context.SaveChangesAsync();
            sb.AppendLine($"Successfully seeded {roomTypeData.Length} room types.");
            return sb.ToString();
        }
        public async Task<string> SeedServices(LuxorDbContext context)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Datasets", "service.txt");
            string[] serviceData = File.ReadAllLines(filePath).Skip(1).ToArray();
            foreach (var line in serviceData)
            {
                string[] data = line.Split(',');
                Service service = new Service
                {
                    ServiceName = data[0],
                    Description = data[1],
                    Price = decimal.Parse(data[2])
                };
                await context.Services.AddAsync(service);
            }
            await context.SaveChangesAsync();
            sb.AppendLine($"Successfully seeded {serviceData.Length} services.");
            return sb.ToString();
        }
        public async Task<string> SeedEmployees(LuxorDbContext context)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Datasets", "employee.txt");
            string[] employeeData = File.ReadAllLines(filePath).Skip(1).ToArray();
            foreach (var line in employeeData)
            {
                string[] data = line.Split(',');
                DateTime hireDate = DateTime.ParseExact(data[4], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Employee employee = new Employee
                {
                    Name = data[0],
                    Age = int.Parse(data[1]),
                    Position = data[2],
                    Salary = decimal.Parse(data[3]),
                    HireDate = hireDate,
                };
                await context.Employees.AddAsync(employee);
            }
            await context.SaveChangesAsync();
            sb.AppendLine($"Successfully seeded {employeeData.Length} employees.");
            return sb.ToString();
        }
        public async Task<string> SeedEmployeeServices(LuxorDbContext context)
        {
            StringBuilder sb = new StringBuilder();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Datasets", "employeeService.txt");
            string[] employeeServiceData = File.ReadAllLines(filePath).Skip(1).ToArray();
            foreach (var line in employeeServiceData)
            {
                string[] data = line.Split(',');
                EmployeeService employeeService = new EmployeeService
                {
                    EmployeeId = int.Parse(data[0]),
                    ServiceId = int.Parse(data[1])
                };
                await context.EmployeesServices.AddAsync(employeeService);
            }
            await context.SaveChangesAsync();
            sb.AppendLine($"Successfully seeded {employeeServiceData.Length} employee services.");
            return sb.ToString();
        }
    }
}
