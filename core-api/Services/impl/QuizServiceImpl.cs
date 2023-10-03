using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using core_api.Models; 
using core_api.Services;
using core_api.Context;
using core_api.Dtos;



namespace core_api.Services
{
    public class QuizService : IQuizService
    {
        private readonly AppDbContext _context; // Replace with your actual DbContext
        private readonly IMapper _mapper; // Add AutoMapper for mapping entities

        public QuizService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResultQuizDto AddQuiz(Quiz quiz)
        {
            try
            {
                _context.Quizzes.Add(quiz);
                _context.SaveChanges();
                return new ResultQuizDto { Success = true, Quiz = _mapper.Map<QuizDto>(quiz) };
            }
            catch (Exception ex)
            {
                return new ResultQuizDto { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public ResultQuizDto UpdateQuiz(Quiz quiz)
        {
            try
            {
                _context.Quizzes.Update(quiz);
                _context.SaveChanges();
                return new ResultQuizDto { Success = true, Quiz = _mapper.Map<QuizDto>(quiz) };
            }
            catch (Exception ex)
            {
                return new ResultQuizDto { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public List<Quiz> GetQuizzes()
        {
            return _context.Quizzes.ToList();
        }

        public ResultQuizDto GetQuizById(long id)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);

            if (quiz != null)
            {
                return new ResultQuizDto { Success = true, Quiz = _mapper.Map<QuizDto>(quiz) };
            }
            else
            {
                return new ResultQuizDto { Success = false, Errors = new List<string> { "Quiz not found" } };
            }
        }

        public ResultQuizDto DeleteQuizById(long id)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);

            if (quiz != null)
            {
                try
                {
                    _context.Quizzes.Remove(quiz);
                    _context.SaveChanges();
                    return new ResultQuizDto { Success = true };
                }
                catch (Exception ex)
                {
                    return new ResultQuizDto { Success = false, Errors = new List<string> { ex.Message } };
                }
            }
            else
            {
                return new ResultQuizDto { Success = false, Errors = new List<string> { "Quiz not found" } };
            }
        }

        public List<Quiz> GetQuizzesByCategory(Category category)
        {
            return _context.Quizzes.Where(q => q.CategoryId == category.Id).ToList();
        }

        public List<Quiz> GetActiveQuizzes()
        {
            return _context.Quizzes.Where(q => q.Active).ToList();
        }

        public List<Quiz> GetActiveQuizzesOfCategory(Category category)
        {
            return _context.Quizzes.Where(q => q.CategoryId == category.Id && q.Active).ToList();
        }
    }
}
