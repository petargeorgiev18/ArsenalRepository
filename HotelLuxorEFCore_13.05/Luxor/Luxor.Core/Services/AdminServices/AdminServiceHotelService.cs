using Luxor.Data;
using Luxor.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxor.Core.Services.AdminServices
{
    public class AdminServiceHotelService
    {
        private readonly LuxorDbContext context;
        public AdminServiceHotelService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> ShowAllServices()
        {
            var allServices = await context.Services.ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("All services:");
            foreach (var service in allServices)
            {
                sb.AppendLine($"ID: {service.ServiceId}, Name: {service.ServiceName}, Price: {service.Price}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowServicesByPriceDesc()
        {
            var services = await context.Services
                .OrderByDescending(s => s.Price)
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine($"Services:");
            foreach (var service in services)
            {
                sb.AppendLine($"ID: {service.ServiceId}, Name: {service.ServiceName}, Price: {service.Price}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowServicesByBooking(int bookingId)
        {
            var services = await context.Services
                .Include(s => s.BookingServices)
                .Where(s => s.BookingServices.Any(bs => bs.BookingId == bookingId))
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Services for Booking ID: {bookingId}");
            foreach (var service in services)
            {
                sb.AppendLine($"Service ID: {service.ServiceId}, Name: {service.ServiceName}, Price: {service.Price}");               
            }

            return sb.ToString();
        }

        public async Task<string> AddServiceToBooking(int bookingId, string serviceName)
        {
            var booking = await context.Bookings.FindAsync(bookingId);
            var service = await context.Services.FirstAsync(s=>s.ServiceName==serviceName);
            if (booking == null || service == null)
            {
                return "Booking or Service not found.";
            }
            booking.BookingServices.Add(new BookingService
            {
                BookingId = booking.BookingId,
                ServiceId = service.ServiceId
            });
            await context.SaveChangesAsync();
            return $"Service {service.ServiceName} added to booking {booking.BookingId}.";
        }
        public async Task<string> RemoveServiceFromBooking(int bookingId, string serviceName)
        {
            var booking = await context.Bookings.FindAsync(bookingId);
            var service = await context.Services.FirstAsync(s => s.ServiceName == serviceName);
            if (booking == null || service == null)
            {
                return "Booking or Service not found.";
            }
            var bookingService = await context.BookingsServices
                .FirstOrDefaultAsync(bs => bs.BookingId == booking.BookingId && bs.ServiceId == service.ServiceId);
            if (bookingService != null)
            {
                context.BookingsServices.Remove(bookingService);
                await context.SaveChangesAsync();
                return $"Service {service.ServiceName} removed from booking {booking.BookingId}.";
            }
            return "Service not found in the booking.";
        }
    }
}
