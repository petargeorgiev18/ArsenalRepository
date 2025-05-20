using System.Text;
using Luxor.Data;
using Luxor.Data.Models;
using Luxor.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Luxor.Core.Services.AdminServices
{
    public class AdminRoomService
    {
        private readonly LuxorDbContext context;
        public AdminRoomService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> ShowAllRoomsAndTheirType()
        {
            var allRooms = await context.Rooms.Include(r => r.RoomType).ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("All rooms:");
            foreach (var room in allRooms)
            {
                sb.AppendLine($"ID: {room.RoomId}, RoomNumber: {room.RoomNumber}, " +
                    $"RoomType: {room.RoomType.Type.ToString()}, Price: {room.Price}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowRoomsByType(string type)
        {
            var rooms = await context.Rooms.Include(r => r.RoomType)
                .Where(r => r.RoomType.Type == (TypeRoom)Enum.Parse(typeof(TypeRoom), type))
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine($"Rooms of type {type}:");
            foreach (var room in rooms)
            {
                sb.AppendLine($"ID: {room.RoomId}, RoomNumber: {room.RoomNumber}, " +
                    $"RoomType: {room.RoomType}, Price: {room.Price}");
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
        public async Task<string> AddRoom(string roomNumber, string description, decimal price, int roomTypeId)
        {
            StringBuilder sb = new StringBuilder();
            var room = new Room
            {
                RoomNumber = roomNumber,
                Description = description,
                Price = price,
                IsAvailable = true,
                RoomTypeId = roomTypeId
            };
            var existingRoom = context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (existingRoom == null)
            {
                context.Rooms.Add(room);
                await context.SaveChangesAsync();
                sb.AppendLine($"Room {room.RoomNumber} added successfully.");
                return sb.ToString();
            }
            sb.AppendLine($"There is existing room with number {roomNumber}");
            return sb.ToString();
        }
        public async Task<string> RemoveRoom(int roomId)
        {
            StringBuilder sb = new StringBuilder();
            var room = await context.Rooms.FirstOrDefaultAsync(r=>r.RoomId==roomId);
            if (room == null)
            {
                sb.AppendLine("Room not found.");
                return sb.ToString();
            }
            context.Rooms.Remove(room);
            await context.SaveChangesAsync();
            sb.AppendLine($"Room {room.RoomNumber} removed successfully.");
            return sb.ToString();
        }
    }
}
