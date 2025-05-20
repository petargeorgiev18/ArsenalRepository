using Luxor.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxor.Core.Controllers.AdminControllers
{
    public class AdminRoomTypeService
    {
        private readonly LuxorDbContext context;
        public AdminRoomTypeService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> ShowAllRoomTypes()
        {
            var allRoomTypes = await context.RoomTypes.ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("All room types:");
            foreach (var roomType in allRoomTypes)
            {
                sb.AppendLine($"TypeRoom: {roomType.Type}");
            }
            return sb.ToString();
        }   
    }
}
