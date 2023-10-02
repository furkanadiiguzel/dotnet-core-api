using System.Collections.Generic;
using System.Threading.Tasks;

namespace core_api.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionsByQuizAsync(Quiz quiz);
        Task<Question> GetQuestionByIdAsync(long id);
        Task<Question> AddQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(Question question);
        Task<bool> DeleteQuestionAsync(long id);
    }

    public class QuestionRepository : IQuestionRepository
    {
        private readonly YourDbContext _dbContext;

        public QuestionRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Question>> GetQuestionsByQuizAsync(Quiz quiz)
        {
            return await _dbContext.Questions
                .Where(q => q.Quiz == quiz)
                .ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(long id)
        {
            return await _dbContext.Questions.FindAsync(id);
        }

        public async Task<Question> AddQuestionAsync(Question question)
        {
            _dbContext.Questions.Add(question);
            await _dbContext.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            _dbContext.Entry(question).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteQuestionAsync(long id)
        {
            var question = await _dbContext.Questions.FindAsync(id);
            if (question == null)
            {
                return false;
            }

            _dbContext.Questions.Remove(question);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
