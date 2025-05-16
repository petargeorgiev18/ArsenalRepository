using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luxor.Data;
using Microsoft.EntityFrameworkCore;

namespace Luxor.Core.Services.GuestServices
{
    public class GuestRoomService
    {
        private readonly LuxorDbContext context;
        public GuestRoomService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> ShowAvailableRooms()
        {
            var rooms = context.Rooms
                .Where(r => r.IsAvailable == true)
                .ToList();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Available rooms:");
            foreach (var room in rooms)
            {
                sb.AppendLine($"RoomNumber: {room.RoomNumber}, " +
                    $"RoomType: {room.RoomType.Type}, Price: {room.Price}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowRoomsByPrice(decimal price)
        {
            var rooms = await context.Rooms
                .Where(r => r.Price == price)
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine($"Rooms with price {price}:");
            foreach (var room in rooms)
            {
                sb.AppendLine($"ID: {room.RoomId}, RoomNumber: {room.RoomNumber}, " +
                    $"RoomType: {room.RoomType}, Price: {room.Price}");
            }
            return sb.ToString();
        }
        public async Task<int> GetRoomIdByRoomNumber(string roomNumber)
        {
            var room = await context.Rooms
                .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
            if (room != null)
            {
                return room.RoomId;
            }
            else
            {
                throw new Exception("Room not found");
            }
        }
    }
}
