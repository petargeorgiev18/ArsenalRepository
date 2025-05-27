using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShow.Core.Intefaces;
using TVShow.Data.Models;
using TVShow.Data;
using Microsoft.EntityFrameworkCore;

namespace TVShow.Core.Services
{
    public class ContestantService : IContestantService
    {
        private readonly TVShowDbContext context;
        public ContestantService(TVShowDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Contestant>> GetAllAsync()
        {
            return await context.Contestants
                .Include(c => c.ShowContestants)
                .ToListAsync();
        }
        public async Task<Contestant?> GetByIdAsync(int id)
        {
            return await context.Contestants
                .Include(c => c.ShowContestants)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task AddAsync(Contestant contestant)
        {
            context.Contestants.Add(contestant);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Contestant contestant)
        {
            context.Contestants.Update(contestant);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var contestant = await context.Contestants.FirstOrDefaultAsync(c=>c.Id==id);
            if (contestant != null)
            {
                context.Contestants.Remove(contestant);
                await context.SaveChangesAsync();
            }
        }
    }
}
