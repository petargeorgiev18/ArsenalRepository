using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luxor.Data;
using Luxor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Luxor.Core.Services.GuestServices
{
    public class GuestFeedbackService
    {
        private readonly LuxorDbContext context;
        public GuestFeedbackService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> SeeAllFeedbacksForRoomType(int guestId)
        {
            var allFeedbacks = await context.Feedbacks.Where(f => f.GuestId == guestId).ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (allFeedbacks != null)
            {
                foreach (var feedback in allFeedbacks)
                {
                    sb.AppendLine($"FeedbackId:{feedback.FeedbackId}");
                    sb.AppendLine($"Comment:{feedback.Comment}");
                    sb.AppendLine($"Rating: {feedback.Rating}");
                    sb.AppendLine($"PublishedOn: {feedback.PublishedOn}");
                    sb.AppendLine($"BookingId: {feedback.BookingId}");
                }
            }
            else
            {
                sb.AppendLine("No feedbacks found for this user.");
            }
            return sb.ToString();
        }
        public async Task<string> SeeFeedbackByBookingIdForUser(int bookingId, int guestId)
        {
            var feedback = await context.Feedbacks.FirstOrDefaultAsync(f => f.BookingId == bookingId
                    && f.GuestId == guestId);
            StringBuilder sb = new StringBuilder();
            if (feedback != null)
            {
                sb.AppendLine($"FeedbackId:{feedback.FeedbackId}");
                sb.AppendLine($"Comment:{feedback.Comment}");
                sb.AppendLine($"Rating: {feedback.Rating}");
                sb.AppendLine($"PublishedOn: {feedback.PublishedOn}");
                sb.AppendLine($"BookingId: {feedback.BookingId}");
            }
            else
            {
                Console.WriteLine("No feedback found for this booking.");
            }
            return sb.ToString();
        }
        public async Task LeaveFeedback(int bookingId, int guestId, string comment, int rating)
        {
            var feedback = new Feedback
            {
                BookingId = bookingId,
                GuestId = guestId,
                Comment = comment,
                Rating = rating,
                PublishedOn = DateTime.Now
            };
            await context.Feedbacks.AddAsync(feedback);
            await context.SaveChangesAsync();
        }
        public async Task<string> UpdateFeedback(int feedbackId, string comment, int rating)
        {
            var feedback = await context.Feedbacks.FirstOrDefaultAsync(f => f.FeedbackId == feedbackId);
            StringBuilder sb = new StringBuilder();
            if (feedback != null)
            {
                feedback.Comment = comment;
                feedback.Rating = rating;
                feedback.PublishedOn = DateTime.UtcNow;
                await context.SaveChangesAsync();
                sb.AppendLine("Feedback updated successfully.");
            }
            else
            {
                sb.AppendLine("No feedback found with this id.");
            }
            return sb.ToString();
        }
        public async Task<string> DeleteFeedback(int feedbackId)
        {
            var feedback = await context.Feedbacks.FirstOrDefaultAsync(f => f.FeedbackId == feedbackId);
            StringBuilder sb = new StringBuilder();
            if (feedback != null)
            {
                context.Feedbacks.Remove(feedback);
                await context.SaveChangesAsync();
                sb.AppendLine("Feedback deleted successfully.");
            }
            else
            {
                sb.AppendLine("No feedback found with this id.");
            }
            return sb.ToString();
        }
        public async Task<string> ShowAllFeedbacksForBookingsForGuest(int guestId)
        {
            StringBuilder sb = new StringBuilder();
            var feedbacks = await context.Feedbacks
                .Include(f => f.Booking)
                .Where(f => f.GuestId == guestId)
                .ToListAsync();
            if (feedbacks != null)
            {
                foreach (var feedback in feedbacks)
                {
                    sb.AppendLine($"FeedbackId:{feedback.FeedbackId}");
                    sb.AppendLine($"Comment:{feedback.Comment}");
                    sb.AppendLine($"Rating: {feedback.Rating}");
                    sb.AppendLine($"PublishedOn: {feedback.PublishedOn}");
                    sb.AppendLine($"BookingId: {feedback.BookingId}");
                }
            }
            else
            {
                sb.AppendLine("No feedbacks found for this user.");
            }
            return sb.ToString();
        }
    }
}
