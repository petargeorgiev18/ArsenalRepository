using EmployeeDepartmentProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeDepartmentProject.Data
{
    public static class DbInitializer
    {
        public static void InitializeAsync(EmployeeDepartmentDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Departments.Any())
                return;

            var departments = new Department[]
            {
                new Department { Name = "Human Resources", Code = "HR" },
                new Department { Name = "Finance", Code = "FIN" },
                new Department { Name = "IT", Code = "IT" },
                new Department { Name = "Marketing", Code = "MKT" },
                new Department { Name = "Sales", Code = "SLS" }
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee { Name = "Alice Johnson", Email = "alice@example.com", DateOfBirth = new DateTime(1990, 5, 12), Salary = 5000, DepartmentId = departments[0].Id },
                new Employee { Name = "Bob Smith", Email = "bob@example.com", DateOfBirth = new DateTime(1985, 8, 20), Salary = 5500, DepartmentId = departments[1].Id },
                new Employee { Name = "Charlie Brown", Email = "charlie@example.com", DateOfBirth = new DateTime(1992, 2, 15), Salary = 6000, DepartmentId = departments[2].Id },
                new Employee { Name = "Diana Prince", Email = "diana@example.com", DateOfBirth = new DateTime(1988, 11, 1), Salary = 6200, DepartmentId = departments[3].Id },
                new Employee { Name = "Ethan Hunt", Email = "ethan@example.com", DateOfBirth = new DateTime(1995, 7, 25), Salary = 5800, DepartmentId = departments[4].Id }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}