using Microsoft.EntityFrameworkCore;
using PartyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyManagement.Data
{
    public class PartyManagementDbContext : DbContext
    {
        public PartyManagementDbContext(DbContextOptions<PartyManagementDbContext> options)
            : base(options)
        {            
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<Party> Parties { get; set; }
    }
}
