using Microsoft.AspNetCore.Mvc;
using core_api.Models;
using System;
using System.Collections.Generic;

namespace core_api.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IQuizService _quizService;

        public QuestionController(IQuestionService questionService, IQuizService quizService)
        {
            _questionService = questionService;
            _quizService = quizService;
        }

        [HttpPost("")]
        public IActionResult AddQuestion([FromBody] Question question)
        {
            try
            {
                var result = _questionService.AddQuestion(question);

                if (result.IsSuccess)
                {
                    return Ok(result.Question);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("")]
        public IActionResult UpdateQuestion([FromBody] Question question)
        {
            try
            {
                var result = _questionService.UpdateQuestion(question);

                if (result.IsSuccess)
                {
                    return Ok(result.Question);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/quiz/{qid}")]
        public IActionResult GetQuestionsOfQuiz(long qid)
        {
            try
            {
                var quizById = _quizService.GetQuizById(qid).Quiz;
                var questions = quizById.Questions;

                if (questions.Count > int.Parse(quizById.NumberOfQuestions))
                {
                    questions = questions.GetRange(0, int.Parse(quizById.NumberOfQuestions));
                }

                questions.Shuffle();

                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/questions/all/{qid}")]
        public IActionResult GetQuestionsOfQuizForAdmin(long qid)
        {
            try
            {
                var quiz = new Quiz { QId = qid };
                return Ok(_questionService.GetQuestionsOfQuiz(quiz));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/{question}")]
        public IActionResult GetQuestion(long question)
        {
            try
            {
                var result = _questionService.GetQuestion(question);
                return result.IsSuccess ? Ok(result.Question) : BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/{question}")]
        public IActionResult DeleteQuestion(long question)
        {
            try
            {
                var result = _questionService.DeleteQuestion(question);
                return result.IsSuccess ? Ok() : BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/submit-exam")]
        public IActionResult CalculateTest([FromBody] List<Question> questions)
        {
            try
            {
                double marksGot = 0;
                int correctAnswer = 0;
                int attempted = 0;

                foreach (var q in questions)
                {
                    var question = _questionService.GetQuestion(q.QuesId).Question;

                    if (question.Answer.Trim().Equals(q.GivenAnswer))
                    {
                        correctAnswer++;

                        double marksOfSingle = double.Parse(questions[0].Quiz.MaxMarks) / questions.Count;
                        marksGot += marksOfSingle;
                    }

                    if (!string.IsNullOrEmpty(q.GivenAnswer))
                    {
                        attempted++;
                    }
                }

                var result = new
                {
                    marksGot,
                    correctAnswers = correctAnswer,
                    attempted
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
