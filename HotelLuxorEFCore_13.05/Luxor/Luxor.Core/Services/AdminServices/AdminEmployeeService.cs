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
    public class AdminEmployeeService
    {
        private readonly LuxorDbContext context;
        public AdminEmployeeService(LuxorDbContext context)
        {
            this.context = context;
        }
        public async Task<string> ShowAllEmployees()
        {
            var allEmployees = await context.Employees.ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("All employees:");
            foreach (var employee in allEmployees)
            {
                sb.AppendLine($"ID: {employee.EmployeeId}, FullName: {employee.FirstName} {employee.LastName}, " +
                    $"Salary: {employee.Salary}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowEmployeeById(int employeeId)
        {
            var employee = await context.Employees
                .Where(e => e.EmployeeId == employeeId)
                .FirstOrDefaultAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine($"Employee with ID {employeeId}:");
            if (employee != null)
            {
                sb.AppendLine($"ID: {employee.EmployeeId}, FullName: {employee.FirstName} {employee.LastName}, " +
                    $"Salary: {employee.Salary}");
            }
            else
            {
                sb.AppendLine($"No employee found with ID {employeeId}");
            }
            return sb.ToString();
        }
        public async Task<string> ShowEmployeesByName(string name)
        {
            string[] names = name.Split(' ');
            var employees = await context.Employees
                .Where(e => e.FirstName == names[0] && e.LastName == names[1])
                .ToListAsync();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine($"Employees with name {name}:");
            foreach (var employee in employees)
            {
                sb.AppendLine($"ID: {employee.EmployeeId}, FullName: {employee.FirstName} {employee.LastName}, " +
                    $"Salary: {employee.Salary}");
            }
            return sb.ToString();
        }
        public void AddEmployee(string name, int age, string position, decimal salary)
        {
            var employee = new Employee
            {
                FirstName = name.Split(' ')[0],
                LastName = name.Split(' ')[1],
                Age = age,
                Position = position,
                Salary = salary,
                HireDate = DateTime.UtcNow
            };
            context.Employees.Add(employee);
            context.SaveChanges();
        }
        public async Task<string> RemoveEmployee(string name, int id)
        {
            string[] names = name.Split(' ');
            StringBuilder sb = new StringBuilder();
            var employee = context.Employees
                .Where(e => e.FirstName == names[0] && e.LastName == names[1] && e.EmployeeId == id)
                .FirstOrDefault();
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
                sb.AppendLine($"Employee with ID {id} and name {name} successfully removed.");
            }
            else
            {
                sb.AppendLine($"No employee found with name {name}");
            }
            return sb.ToString();
        }
    }
}
