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
    public class UniversityController
    {
        private UniversityDbContext context;

        public UniversityController(UniversityDbContext context)
        {
            this.context = context;
        }
        public async Task AddUniversity(string name)
        {
            var university = new University
            {
                Name = name
            };
            await context.Universities.AddAsync(university);
            await context.SaveChangesAsync();
        }
        public async Task<List<University>> GetAllUniversities()
        {
            return await context.Universities.ToListAsync();
        }
        public async Task<University?> GetUniversityByName(string name)
        {
            return await context.Universities
                .FirstOrDefaultAsync(u => u.Name == name);
        }
        public async Task<int?> GetUniversityIdByName(string name)
        {
            University? university = await GetUniversityByName(name);
            return university.Id;
        }
    }
}
