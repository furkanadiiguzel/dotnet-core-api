using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using core_api.Models;



namespace core_api.Repositories
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetQuizzesByCategoryAsync(Category category);
        Task<IEnumerable<Quiz>> GetActiveQuizzesAsync();
        Task<IEnumerable<Quiz>> GetActiveQuizzesByCategoryAsync(Category category);
        Task<Quiz> GetQuizByIdAsync(long id);
        Task<Quiz> AddQuizAsync(Quiz quiz);
        Task<Quiz> UpdateQuizAsync(Quiz quiz);
        Task<bool> DeleteQuizAsync(long id);
    }

    public class QuizRepository : IQuizRepository
    {
        private readonly YourDbContext _dbContext;

        public QuizRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Quiz>> GetQuizzesByCategoryAsync(Category category)
        {
            return await _dbContext.Quizzes
                .Where(q => q.Category == category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Quiz>> GetActiveQuizzesAsync()
        {
            return await _dbContext.Quizzes
                .Where(q => q.Active)
                .ToListAsync();
        }

        public async Task<IEnumerable<Quiz>> GetActiveQuizzesByCategoryAsync(Category category)
        {
            return await _dbContext.Quizzes
                .Where(q => q.Category == category && q.Active)
                .ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(long id)
        {
            return await _dbContext.Quizzes.FindAsync(id);
        }

        public async Task<Quiz> AddQuizAsync(Quiz quiz)
        {
            _dbContext.Quizzes.Add(quiz);
            await _dbContext.SaveChangesAsync();
            return quiz;
        }

        public async Task<Quiz> UpdateQuizAsync(Quiz quiz)
        {
            _dbContext.Entry(quiz).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return quiz;
        }

        public async Task<bool> DeleteQuizAsync(long id)
        {
            var quiz = await _dbContext.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return false;
            }

            _dbContext.Quizzes.Remove(quiz);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
