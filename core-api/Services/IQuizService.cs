using System.Collections.Generic;
using core_api.Models; // Replace with your actual model namespace

namespace core_api.Services
{
    public interface IQuizService
    {
        ResultQuizDto AddQuiz(Quiz quiz);

        ResultQuizDto UpdateQuiz(Quiz quiz);

        List<Quiz> GetQuizzes();

        ResultQuizDto GetQuizById(long id);

        ResultQuizDto DeleteQuizById(long id);

        List<Quiz> GetQuizzesByCategory(Category category);

        List<Quiz> GetActiveQuizzes();

        List<Quiz> GetActiveQuizzesOfCategory(Category category);
    }
}
