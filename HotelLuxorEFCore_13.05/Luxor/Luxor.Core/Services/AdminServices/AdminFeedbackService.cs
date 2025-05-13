using Luxor.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxor.Core.Services.AdminServices
{
    public class AdminFeedbackService
    {
        private readonly LuxorDbContext context;
        public AdminFeedbackService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> ShowAllFeedbacks()
        {
            var allFeedbacks = await context.Feedbacks.ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("All feedbacks:");
            foreach (var feedback in allFeedbacks)
            {
                sb.AppendLine($"ID: {feedback.FeedbackId}, BookingId: {feedback.BookingId}, " +
                    $"Rating: {feedback.Rating}, Comment: {feedback.Comment}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowFeedbacksByRating(int rating)
        {
            var feedbacks = await context.Feedbacks
                .Where(f => f.Rating == rating)
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine($"Feedbacks with rating {rating}:");
            foreach (var feedback in feedbacks)
            {
                sb.AppendLine($"BookingId: {feedback.BookingId}, " +
                    $"Rating: {feedback.Rating}, Comment: {feedback.Comment}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowAllFeedbacksByBookingIdOrderedByRatingDesc(int bookingId)
        {
            var feedbacks = await context.Feedbacks
                .Where(f => f.BookingId == bookingId)
                .OrderByDescending(f => f.Rating)
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine($"Feedbacks for booking with ID {bookingId}:");
            foreach (var feedback in feedbacks)
            {
                sb.AppendLine($"ID: {feedback.FeedbackId}, BookingId: {feedback.BookingId}, " +
                    $"Rating: {feedback.Rating}, Comment: {feedback.Comment}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowFeedbacksByRatingForBooking(int rating, int bookingId)
        {
            var feedbacks = await context.Feedbacks
                .Where(f => f.Rating == rating && f.BookingId == bookingId)
                .OrderByDescending(f => f.Rating)
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (feedbacks.Count != 0)
            {
                Console.WriteLine($"Feedbacks with rating {rating} for booking with ID {bookingId}:");
                foreach (var feedback in feedbacks)
                {
                    sb.AppendLine($"ID: {feedback.FeedbackId}, BookingId: {feedback.BookingId}, " +
                        $"Rating: {feedback.Rating}, Comment: {feedback.Comment}");
                }
            }
            else
            {
                sb.AppendLine($"No feedbacks with rating {rating} for booking with ID {bookingId} found.");
            }
            return sb.ToString();
        }
    }
}
