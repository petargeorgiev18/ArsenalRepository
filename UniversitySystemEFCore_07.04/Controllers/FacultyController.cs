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
    public class FacultyController
    {
        private UniversityDbContext context;
        public FacultyController(UniversityDbContext context)
        {
            this.context = context;
        }
        public async Task AddFaculty(string name, int universityId)
        {
            var faculty = new Faculty
            {
                Name = name,
                UniversityId = universityId,
            };
            await context.Faculties.AddAsync(faculty);
            await context.SaveChangesAsync();
        }
        public async Task<List<Faculty>> GetFacultiesByUniversityId(int universityId)
        {
            return await context.Faculties.Where(f=>f.UniversityId==universityId).ToListAsync();
        }
        public async Task<List<Faculty>> GetFacultiesByName(string name)
        {
            return await context.Faculties
                .Where(f => f.Name == name).ToListAsync();
        }
        public async Task<Faculty?> GetFacultyByNameAndUniversityId(string name, int universityId)
        {
            return await context.Faculties.FirstOrDefaultAsync(f=>f.Name==name && f.Id == universityId);
        }
    }
}
