using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luxor.Data;
using Luxor.Data.Models;
using Luxor.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Luxor.Core.Services.GuestServices
{
    public class GuestBookingService
    {
        private readonly LuxorDbContext context;
        public GuestBookingService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> SeeAllBookingsByUser(int guestId)
        {
            var allBookings = await context.Bookings.Where(b => b.GuestId == guestId).ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (allBookings != null)
            {
                foreach (var booking in allBookings)
                {
                    sb.AppendLine($"BookingId:{booking.BookingId}");
                    sb.AppendLine($"AccommodationDate:{booking.AccommodationDate}");
                    sb.AppendLine($"LeavingDate: {booking.LeavingDate}");
                    sb.AppendLine($"Amount: {booking.Amount}");
                    sb.AppendLine($"PaymentDate: {booking.PaymentDate}");
                    sb.AppendLine($"PaymentMethod: {booking.PaymentMethod}");
                    sb.AppendLine($"Status: {booking.Status}");
                }
            }
            else
            {
                sb.AppendLine("No bookings found for this user.");
            }
            return sb.ToString();
        }
        public async Task SeeBookingInfoByGuestId(int guestId, int bookingId)
        {
            var booking = await context.Bookings.FirstOrDefaultAsync(b => b.GuestId == guestId
                    && b.BookingId == bookingId);
            StringBuilder sb = new StringBuilder();
            if (booking != null)
            {
                sb.AppendLine($"BookingId:{booking.BookingId}");
                sb.AppendLine($"AccommodationDate:{booking.AccommodationDate}");
                sb.AppendLine($"LeavingDate: {booking.LeavingDate}");
                sb.AppendLine($"Amount: {booking.Amount}");
                sb.AppendLine($"PaymentDate: {booking.PaymentDate}");
                sb.AppendLine($"PaymentMethod: {booking.PaymentMethod}");
                sb.AppendLine($"Status: {booking.Status}");
            }
            else
            {
                Console.WriteLine("No booking with this id found for this user.");
            }
        }
        public async Task AddBooking(int guestId, int roomId, DateTime leavingDate,
            decimal amount, string paymentMethod, Status status)
        {
            var booking = new Booking
            {
                GuestId = guestId,
                RoomId = roomId,
                AccommodationDate = DateTime.UtcNow,
                LeavingDate = leavingDate,
                Amount = amount,
                PaymentDate = leavingDate,
                PaymentMethod = paymentMethod,
                Status = status
            };
            await context.Bookings.AddAsync(booking);
            await context.SaveChangesAsync();
        }
        public async Task UpdateBooking(int bookingId, DateTime accommodationDate, DateTime leavingDate,
            decimal amount, DateTime paymentDate, string paymentMethod, Status status)
        {
            var booking = await context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                booking.AccommodationDate = accommodationDate;
                booking.LeavingDate = leavingDate;
                booking.Amount = amount;
                booking.PaymentDate = paymentDate;
                booking.PaymentMethod = paymentMethod;
                booking.Status = status;
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("No booking with this id found.");
            }
        }
        public async Task DeleteBooking(int bookingId)
        {
            var booking = await context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                context.Bookings.Remove(booking);
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("No booking with this id found.");
            }
        }
    }
}
