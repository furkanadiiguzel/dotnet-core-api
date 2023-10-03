using Microsoft.AspNetCore.Mvc;
using core_api.Models;
using System;
using core_api.Services;
using core_api.Dtos;


namespace core_api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("")]
        public IActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                var result = _categoryService.AddCategory(category);

                if (result.IsSuccess)
                {
                    return Ok(result.Category);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                var result = _categoryService.UpdateCategory(category);

                if (result.IsSuccess)
                {
                    return Ok(result.Category);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{category_id}")]
        public IActionResult GetCategory(long category_id)
        {
            try
            {
                var result = _categoryService.GetCategoryById(category_id);

                if (result.IsSuccess)
                {
                    return Ok(result.Category);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("category")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _categoryService.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{category_id}")]
        public IActionResult DeleteCategory(long category_id)
        {
            try
            {
                var result = _categoryService.DeleteCategoryById(category_id);

                if (result.IsSuccess)
                {
                    return Ok();
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
