using Luxor.Data;
using Luxor.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Luxor.Core.Services.AdminServices
{
    public class AdminBookingService
    {
        private readonly LuxorDbContext context;
        public AdminBookingService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> ShowAllBookings()
        {
            var allBookings = await context.Bookings.ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("All bookings:");
            foreach (var booking in allBookings)
            {
                sb.AppendLine($"ID: {booking.BookingId}, GuestId: {booking.GuestId}, " +
                    $"RoomId: {booking.RoomId}, AccomodationDate: {booking.AccommodationDate}, " +
                    $"LeavingDate: {booking.LeavingDate}, Amount: {booking.Amount}, Status: {booking.Status}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowBookingsByGuestId(int guestId)
        {
            var bookings = await context.Bookings
                .Where(b => b.GuestId == guestId)
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (bookings.Count == 0)
            {
                sb.AppendLine("No bookings found.");
                return sb.ToString();
            }
            Console.WriteLine($"Bookings for guest with ID {guestId}:");
            foreach (var booking in bookings)
            {
                sb.AppendLine($"ID: {booking.BookingId}, GuestId: {booking.GuestId}, " +
                    $"RoomId: {booking.RoomId}, AccomodationDate: {booking.AccommodationDate}, " +
                    $"LeavingDate: {booking.LeavingDate}, Amount: {booking.Amount}, Status: {booking.Status}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowBookingsByRoomNumber(string roomNumber)
        {
            var bookings = await context.Bookings.Include(b => b.Room)
                .Where(r => r.Room.RoomNumber == roomNumber)
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (bookings.Count == 0)
            {
                sb.AppendLine("No bookings found.");
                return sb.ToString();
            }
            Console.WriteLine($"Bookings for room with number {roomNumber}:");
            foreach (var booking in bookings)
            {
                sb.AppendLine($"ID: {booking.BookingId}, GuestId: {booking.GuestId}, " +
                    $"RoomId: {booking.RoomId}, AccomodationDate: {booking.AccommodationDate}, " +
                    $"LeavingDate: {booking.LeavingDate}, Amount: {booking.Amount}, Status: {booking.Status}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowBookingsByStatus(string status)
        {
            var reservedBookings = await context.Bookings
                .Where(b => b.Status == (Status)Enum.Parse(typeof(Status), status))
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (reservedBookings.Count == 0)
            {
                sb.AppendLine("No bookings found.");
                return sb.ToString();
            }
            sb.AppendLine($"Bookings with reserved status:");
            foreach (var booking in reservedBookings)
            {
                sb.AppendLine($"ID: {booking.BookingId}, GuestId: {booking.GuestId}, " +
                    $"RoomId: {booking.RoomId}, AccomodationDate: {booking.AccommodationDate}, " +
                    $"LeavingDate: {booking.LeavingDate}, Amount: {booking.Amount}, Status: {booking.Status}");
            }
            return sb.ToString();
        }
        public async Task<string> ChangeStatusOfBooking(int bookingId, string status)
        {
            var booking = await context.Bookings
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
            StringBuilder sb = new StringBuilder();
            if (booking != null)
            {
                bool tryChange = Enum.TryParse(status, out Status parsedStatus);
                if (tryChange)
                {
                    booking.Status = parsedStatus;
                }
                else
                {
                    sb.AppendLine("Invalid status.");
                    return sb.ToString();
                }
                await context.SaveChangesAsync();
                sb.AppendLine($"Booking with ID {bookingId} status changed to {status}.");
            }
            else
            {
                sb.AppendLine("No booking found with this ID.");
            }
            return sb.ToString();
        }
    }
}
