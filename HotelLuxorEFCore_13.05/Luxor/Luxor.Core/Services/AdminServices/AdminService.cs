using Luxor.Data;
using Luxor.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxor.Core.Services.AdminServices
{
    public class AdminService
    {
        private readonly LuxorDbContext context;
        public AdminService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> CheckIfAdmin(string guestFirstName, string guestLastName, string email, string phoneNumber,
            string password)
        {           
            if (guestFirstName == "Admin" && guestLastName == "Adminov" && email == "admin@gmail.com" && phoneNumber == "555-0000" &&
                password == "admin123")
            {
                return true;
            }
            return false;
        }
    }
}
