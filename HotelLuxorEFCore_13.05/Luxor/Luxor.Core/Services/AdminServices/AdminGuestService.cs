using Luxor.Data;
using Luxor.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxor.Core.Services.AdminServices
{
    public class AdminGuestService
    {
        private readonly LuxorDbContext context;
        public AdminGuestService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> ShowAllGuests()
        {
            var allGuests = await context.Guests.ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("All guests:");
            foreach (var guest in allGuests)
            {
                sb.AppendLine($"ID: {guest.GuestId}, First Name: {guest.FirstName}, Last Name: {guest.LastName}, Email: {guest.Email}, " +
                    $"PhoneNumber: {guest.PhoneNumber}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowGuestsByLastName(string name)
        {
            var guests = await context.Guests
                .Where(g => g.LastName == name)
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (guests != null)
            {
                Console.WriteLine($"Guest with last name {name}:");
                foreach (var guest in guests)
                {
                    sb.AppendLine($"ID: {guest.GuestId}, Name: {guest.LastName}, Email: {guest.Email}, " +
                        $"PhoneNumber: {guest.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine($"No guests with last name {name} found.");
            }
            return sb.ToString();
        }
        public async Task<string> ShowGuestByGivenFullName(string firstName, string lastName)
        {
            var guests = await context.Guests
                .Where(g => g.FirstName == firstName || g.LastName == lastName)
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (guests == null)
            {
                sb.AppendLine($"No guests with full name {firstName} {lastName} found.");
                return sb.ToString();
            }
            Console.WriteLine($"Guest with full name {firstName} {lastName}:");
            foreach (var guest in guests)
            {
                sb.AppendLine($"ID: {guest.GuestId}, Name: {guest.LastName}, Email: {guest.Email}, " +
                    $"PhoneNumber: {guest.PhoneNumber}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowGuestsWhichFirstNameStartsWithGivenLetter(char letter)
        {
            var guests = await context.Guests
                .Where(g => g.FirstName.ToLower().StartsWith(letter.ToString()))
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (guests != null)
            {
                sb.AppendLine($"Guests with first name starting with {letter}:");
                foreach (var guest in guests)
                {
                    sb.AppendLine($"ID: {guest.GuestId}, First name: {guest.FirstName}, Last name: {guest.LastName}, Email: {guest.Email}, " +
                        $"PhoneNumber: {guest.PhoneNumber}");
                }
            }
            else
            {
                sb.AppendLine($"No guests with first name starting with {letter} found.");
            }
            return sb.ToString();
        }
        public async Task<string> ShowGuestsWhichLastNameStartsWithGivenLetter(char letter)
        {
            var guests = await context.Guests
                .Where(g => g.LastName.ToLower().StartsWith(letter.ToString()))
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            if (guests != null)
            {
                Console.WriteLine($"Guests with first name starting with {letter}:");
                foreach (var guest in guests)
                {
                    sb.AppendLine($"ID: {guest.GuestId}, First name: {guest.FirstName}, Last name: {guest.LastName} Email: {guest.Email}, " +
                        $"PhoneNumber: {guest.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine($"No guests with first name starting with {letter} found.");
            }
            return sb.ToString();
        }
        public async Task<Guest> CheckIfGuestExists(string guestFirstName, string guestLastName, string email, string phoneNumber,
            string password)
        {
            Guest guest = await context.Guests.FirstOrDefaultAsync(g => g.FirstName == guestFirstName &&
                g.LastName == guestLastName && g.Email == email && g.PhoneNumber == phoneNumber && g.Password == password);
            if (guest != null)
            {
                return guest;
            }
            return null;
        }
        public async Task<string> RegisterGuest(string firstName, string lastName, string email, string phoneNumber,
            string password)
        {
            StringBuilder sb = new StringBuilder();
            var guest = new Guest
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Password = password
            };
            var existingGuest = await context.Guests
                .FirstOrDefaultAsync(g => g.FirstName == firstName && g.LastName == lastName 
                && g.Email == email && g.PhoneNumber == phoneNumber && g.Password == password);
            if (existingGuest != null)
            {
                sb.AppendLine("Guest already exists.");
                return sb.ToString();
            }
            await context.Guests.AddAsync(guest);
            await context.SaveChangesAsync();
            sb.AppendLine("Guest successfully registered.");
            return sb.ToString();
        }
    }
}