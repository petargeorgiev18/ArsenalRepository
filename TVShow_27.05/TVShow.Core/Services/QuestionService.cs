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
    public class QuestionService : IQuestionService
    {
        private readonly TVShowDbContext context;
        public QuestionService(TVShowDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await context.Questions
                .Include(q => q.Quiz)
                .ToListAsync();
        }
        public async Task<Question?> GetByIdAsync(int id)
        {
            return await context.Questions
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task AddAsync(Question question)
        {
            context.Questions.Add(question);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Question question)
        {
            context.Questions.Update(question);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var question = await context.Questions.FirstOrDefaultAsync(q => q.Id == id);
            if (question != null)
            {
                context.Questions.Remove(question);
                await context.SaveChangesAsync();
            }
        }
    }
}
