using EmployeeDepartmentProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentProject.Data
{
    public class EmployeeDepartmentDbContext : DbContext
    {
        public EmployeeDepartmentDbContext(DbContextOptions<EmployeeDepartmentDbContext> options)
            : base(options)
        {          
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
