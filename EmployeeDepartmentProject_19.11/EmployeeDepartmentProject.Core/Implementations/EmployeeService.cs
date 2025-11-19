using EmployeeDepartmentProject.Core.Interfaces;
using EmployeeDepartmentProject.Data;
using EmployeeDepartmentProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentProject.Core.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDepartmentDbContext _context;
        public EmployeeService(EmployeeDepartmentDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees
                       .Include(e => e.Department)
                       .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                      .Include(e => e.Department)
                      .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
