using Microsoft.EntityFrameworkCore;
using Presents.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presents.Data
{
    public class PresentsDbContext : DbContext
    {
        public PresentsDbContext(DbContextOptions<PresentsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Gift> Gifts { get; set; } = null!;
    }
}
