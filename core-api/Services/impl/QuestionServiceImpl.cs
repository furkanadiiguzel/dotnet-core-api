using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using core_api.Models; // Replace with your actual model namespace

namespace core_api.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context; // Replace with your actual DbContext
        private readonly IMapper _mapper; // Add AutoMapper for mapping entities

        public QuestionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResultQuestionDto AddQuestion(Question question)
        {
            try
            {
                _context.Questions.Add(question);
                _context.SaveChanges();
                return new ResultQuestionDto { Success = true, Question = _mapper.Map<QuestionDto>(question) };
            }
            catch (Exception ex)
            {
                return new ResultQuestionDto { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public ResultQuestionDto UpdateQuestion(Question question)
        {
            try
            {
                _context.Questions.Update(question);
                _context.SaveChanges();
                return new ResultQuestionDto { Success = true, Question = _mapper.Map<QuestionDto>(question) };
            }
            catch (Exception ex)
            {
                return new ResultQuestionDto { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public List<Question> GetQuestions()
        {
            return _context.Questions.ToList();
        }

        public ResultQuestionDto GetQuestion(long id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);

            if (question != null)
            {
                return new ResultQuestionDto { Success = true, Question = _mapper.Map<QuestionDto>(question) };
            }
            else
            {
                return new ResultQuestionDto { Success = false, Errors = new List<string> { "Question not found" } };
            }
        }

        public ResultQuestionDto DeleteQuestionById(long id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);

            if (question != null)
            {
                try
                {
                    _context.Questions.Remove(question);
                    _context.SaveChanges();
                    return new ResultQuestionDto { Success = true };
                }
                catch (Exception ex)
                {
                    return new ResultQuestionDto { Success = false, Errors = new List<string> { ex.Message } };
                }
            }
            else
            {
                return new ResultQuestionDto { Success = false, Errors = new List<string> { "Question not found" } };
            }
        }

        public List<Question> GetQuestionsOfQuiz(Quiz quiz)
        {
            return _context.Questions.Where(q => q.QuizId == quiz.Id).ToList();
        }
    }
}
