using System.Collections.Generic;
using core_api.Models;
using core_api.Dtos;


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
