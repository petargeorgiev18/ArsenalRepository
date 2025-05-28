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
    public class QuizService : IQuizService
    {
        private readonly TVShowDbContext context;
        public QuizService(TVShowDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await context.Quizzes
                .Include(q => q.Questions)
                .Include(q => q.Show)
                .ToListAsync();
        }
        public async Task<Quiz?> GetByIdAsync(int id)
        {
            return await context.Quizzes
                .Include(q => q.Questions)
                .Include(q => q.Show)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task AddAsync(Quiz quiz)
        {
            context.Quizzes.Add(quiz);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Quiz quiz)
        {
            context.Quizzes.Update(quiz);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var quiz = await context.Quizzes.FirstOrDefaultAsync(qz => qz.Id == id);
            if (quiz != null)
            {
                context.Quizzes.Remove(quiz);
                await context.SaveChangesAsync();
            }
        }
    }
}
