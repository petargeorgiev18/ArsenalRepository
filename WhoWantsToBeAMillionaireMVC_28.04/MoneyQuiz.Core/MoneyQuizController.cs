using Microsoft.EntityFrameworkCore;
using MoneyQuiz;
using MoneyQuiz.Data.Data;
using MoneyQuiz.Data.Data.Models;
using System.Runtime.CompilerServices;
using System.Text;

namespace MoneyQuiz.Core
{
    public class MoneyQuizController
    {
        MoneyQuizContext context;
        public MoneyQuizController(MoneyQuizContext context)
        {
            this.context = context;
        }
        public async Task AddQuestion(Question question)
        {
            await context.Questions.AddAsync(question);
            await context.SaveChangesAsync();
        }
        public async Task AddAnswersToQuestion(Question question, List<Answer> answers)
        {
            for (int i = 0; i < 4; i++)
            {
                question.Answers.Add(answers[i]);
            }
            await context.SaveChangesAsync();
        }
        public void EditQuestionById(int id, string questionText)
        {
            var q = context.Questions.FirstOrDefault(q => q.Id == id);
            if (q != null)
            {
                q.Question_Text = questionText;
                context.SaveChanges();
            }
        }
        public async Task EditAnswerById(int id, string answerText, bool isCorrect)
        {
            var a = await context.Answers.FirstOrDefaultAsync(a => a.Id == id);
            if (a != null)
            {
                a.Answer_Text = answerText;
                a.Is_Correct = isCorrect;
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteLifelineById(int id)
        {
            var q = context.Questions.FirstOrDefault(q => q.Id == id);
            if (q != null)
            {
                context.Questions.Remove(q);
                await context.SaveChangesAsync();
            }
        }
        public async Task AddPlayer(Player player)
        {
            await context.Players.AddAsync(player);
            await context.SaveChangesAsync();
        }
        public async Task<string> GetTextOfAllQuestionsWithAmountMoreThan3000()
        {
            StringBuilder sb = new StringBuilder();
            List<string> questions = await context.Questions
                .Where(q => q.Amount > 3000)
                .Select(q => q.Question_Text)
                .ToListAsync();
            foreach (var question in questions)
            {
                sb.AppendLine(question);
            }
            return sb.ToString();
        }
        public async Task<string> GetQuestionTextsAndAnswersForEachQuestion()
        {
            StringBuilder sb = new StringBuilder();
            var questionsAndAnswers = await context.Questions.Include(q => q.Answers).ToListAsync();
            foreach (var question in questionsAndAnswers)
            {
                sb.AppendLine($"Въпрос: {question.Question_Text}");
                int br = 1;
                foreach (var answer in question.Answers)
                {
                    sb.AppendLine($"Отговор {br}: {answer.Answer_Text}");
                    br++;
                }
            }
            return sb.ToString();
        }
        public async Task<string> GetQuestionTextAndAnswerByAmount(int amount)
        {
            StringBuilder sb = new StringBuilder();
            var questionsAndAnswers = await context.Questions.Include(q => q.Answers)
                .Where(q => q.Amount == amount).ToListAsync();
            if (questionsAndAnswers != null)
            {
                foreach (var question in questionsAndAnswers)
                {
                    sb.AppendLine($"{question.Question_Text} -> {question.Answers.First(x => x.Is_Correct).Answer_Text}");
                }
            }
            return sb.ToString();
        }
    }
}
