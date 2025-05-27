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
    public class ShowService : IShowService
    {
        private readonly TVShowDbContext context;
        public ShowService(TVShowDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Show>> GetAllAsync()
        {
            return await context.Shows
                .Include(s => s.Quizzes)
                .Include(s => s.ShowContestants)
                .ToListAsync();
        }
        public async Task<Show?> GetByIdAsync(int id)
        {
            return await context.Shows
                .Include(s => s.Quizzes)
                .Include(s => s.ShowContestants)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task AddAsync(Show show)
        {
            context.Shows.Add(show);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Show show)
        {
            context.Shows.Update(show);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var show = await context.Shows.FirstOrDefaultAsync(s=>s.Id == id);
            if (show != null)
            {
                context.Shows.Remove(show);
                await context.SaveChangesAsync();
            }
        }
    }
}
