using EmployeeDepartmentProject.Core.Interfaces;
using EmployeeDepartmentProject.Data;
using EmployeeDepartmentProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentProject.Core.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly EmployeeDepartmentDbContext _context;
        public DepartmentService(EmployeeDepartmentDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}