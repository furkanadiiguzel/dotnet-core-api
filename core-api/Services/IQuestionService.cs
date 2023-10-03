using System.Collections.Generic;
using core_api.Models; 
using core_api.Dtos;



namespace core_api.Services
{
    public interface IQuestionService
    {
        ResultQuestionDto AddQuestion(Question question);

        ResultQuestionDto UpdateQuestion(Question question);

        List<Question> GetQuestions();

        ResultQuestionDto GetQuestion(long id);

        ResultQuestionDto DeleteQuestionById(long id);

        List<Question> GetQuestionsOfQuiz(Quiz quiz);

    }
}
