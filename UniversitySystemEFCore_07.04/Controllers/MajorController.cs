using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystemEFCore.Data;
using UniversitySystemEFCore.Data.Models;

namespace UniversitySystemEFCore.Controllers
{
    public class MajorController
    {
        private UniversityDbContext context;
        public MajorController(UniversityDbContext context)
        {
            this.context = context;
        }
        public async Task AddMajor(string name, int facultyId)
        {
            var major = new Major
            {
                Name = name,
                FacultyId = facultyId,
            };
            await context.Majors.AddAsync(major);
            await context.SaveChangesAsync();
        }
        public async Task<List<Major>> GetMajorsByFacultyId(int facultyId)
        {
            return await context.Majors.Where(m => m.FacultyId == facultyId).ToListAsync();
        }
        public async Task<List<Major>> GetMajorsByName(string name)
        {
            return await context.Majors
                .Where(m => m.Name == name).ToListAsync();
        }
        public async Task<Major?> GetMajorByNameAndFacultyId(string name, int facultyId)
        {
            return await context.Majors
                .FirstOrDefaultAsync(m => m.Name == name && m.FacultyId == facultyId);
        }
    }
}
