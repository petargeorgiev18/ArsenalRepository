using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luxor.Data;
using Microsoft.EntityFrameworkCore;

namespace Luxor.Core.Services.GuestService
{
    public class GuestService
    {
        private readonly LuxorDbContext context;
        public GuestService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> SeeInformationAboutGuest(int guestId)
        {
            var guest = await context.Guests.FirstOrDefaultAsync(g => g.GuestId == guestId);
            StringBuilder sb = new StringBuilder();
            if (guest != null)
            {
                sb.AppendLine($"FirstName:{guest.FirstName}");
                sb.AppendLine($"LastName: {guest.LastName}");
                sb.AppendLine($"Email: {guest.Email}");
                sb.AppendLine($"PhoneNumber: {guest.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("No user with this id found.");
            }
            return sb.ToString();
        }
        public async Task<string> UpdateInfoForGuest(int guestId, string firstName, string lastName, string email, string phoneNumber, string password)
        {
            var guest = await context.Guests.FirstOrDefaultAsync(g => g.GuestId == guestId);
            StringBuilder sb = new StringBuilder();
            if (guest != null)
            {
                guest.FirstName = firstName;
                guest.LastName = lastName;
                guest.Email = email;
                guest.PhoneNumber = phoneNumber;
                guest.Password = password;
                await context.SaveChangesAsync();
                sb.AppendLine($"Guest with ID {guestId} updated successfully.");
            }
            else
            {
                sb.AppendLine($"No user with ID {guestId} found.");
            }
            return sb.ToString();
        }
    }
}
