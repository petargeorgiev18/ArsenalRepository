using HotelManager.Data;
using HotelManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class HotelController
    {
        private readonly HotelManagerContext context = new HotelManagerContext();
        public HotelController(HotelManagerContext context)
        {
            this.context = context;
        }
        public void GetNamesOfAllGuests()
        {
            var guests = context.Guests
                .Select(g => new { g.FirstName, g.LastName })
                .ToList();

            foreach (var guest in guests)
            {
                Console.WriteLine($"{guest.FirstName} {guest.LastName}");
            }
        }
        public void AddNewGuest(string firstName, string lastName, string phoneNumber, string ucn)
        {
            var newGuest = new Guest
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Ucn = ucn
            };
            context.Guests.Add(newGuest);
            context.SaveChanges();
            Console.WriteLine("Гостът е успешно добавен.");
        }
        public void GetRoomsBetween80And100()
        {
            var rooms = context.Rooms.Where(r => r.Price >= 80 && r.Price <= 100)
                .OrderByDescending(p => p.Price).ToList();
            foreach (var room in rooms)
            {
                Console.WriteLine($"{room.Number}");
            }
        }
        public bool DeleteReservationById(int reservationId)
        {
            var reservation = context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                context.Reservations.Remove(reservation);
                context.SaveChanges();
                Console.WriteLine($"Резервацията с ID {reservationId} бе успешно изтрита.");
                return true;
            }
            Console.WriteLine($"Резервацията с ID {reservationId} не бе намерена.");
            return false;
        }
        public void GetAllFreeRooms()
        {
            var rooms = context.Rooms.Where(r=>r.Status=="free")
                .OrderByDescending(r=>r.Price).ToList();
            Console.WriteLine($"Свободни стаи: {rooms.Count()}");
        }
        public void GetMinimalPriceByStatus(string status)
        {
            Room minimalRoomPrice = context.Rooms.Where(r => r.Status == status)
                .OrderBy(r=>r.Price).First();
            Console.WriteLine($"Минимална цена: {minimalRoomPrice.Price:f2} лв ");
        }
        public void GetAllActiveReservations()
        {
            var reservations = context.Reservations.Where(r=>
                r.ReleaseDate > DateOnly.FromDateTime(DateTime.Today)).ToList();
            Console.WriteLine($"Резервации, които още не са приключили:");
            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation.Id);
            }
        }
    }
}
