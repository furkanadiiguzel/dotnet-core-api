using Microsoft.AspNetCore.Mvc;
using core_api.Models;
using System;
using System.Collections.Generic;

namespace core_api.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost("")]
        public IActionResult AddQuiz([FromBody] Quiz quiz)
        {
            try
            {
                var result = _quizService.AddQuiz(quiz);

                if (result.IsSuccess)
                {
                    return Ok(result.Quiz);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("")]
        public IActionResult UpdateQuiz([FromBody] Quiz quiz)
        {
            try
            {
                var result = _quizService.UpdateQuiz(quiz);

                if (result.IsSuccess)
                {
                    return Ok(result.Quiz);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/")]
        public IActionResult GetQuizzes()
        {
            try
            {
                return Ok(_quizService.GetQuizzes());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/{quiz_id}")]
        public IActionResult GetQuiz(long quiz_id)
        {
            try
            {
                var quizById = _quizService.GetQuizById(quiz_id);
                return quizById.IsSuccess ? Ok(quizById.Quiz) : BadRequest(quizById.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/{quiz_id}")]
        public IActionResult DeleteQuiz(long quiz_id)
        {
            try
            {
                var result = _quizService.DeleteQuizById(quiz_id);
                return result.IsSuccess ? Ok() : BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/category/{category_id}")]
        public IActionResult GetQuizByCategory(long category_id)
        {
            try
            {
                var category = new Category { CId = category_id };
                return Ok(_quizService.GetQuizzesByCategory(category));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/active")]
        public IActionResult GetActiveQuizzes()
        {
            try
            {
                return Ok(_quizService.GetActiveQuizzes());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/category/active/{category_id}")]
        public IActionResult GetActiveQuizByCategory(long category_id)
        {
            try
            {
                var category = new Category { CId = category_id };
                return Ok(_quizService.GetActiveQuizzesOfCategory(category));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
