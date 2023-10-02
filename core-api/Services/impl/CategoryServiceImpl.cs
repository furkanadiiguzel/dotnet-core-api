using System;
using System.Collections.Generic;
using System.Linq;

namespace core_api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context; // Replace with your actual DbContext

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public ResultCategoryDto AddCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return new ResultCategoryDto { Success = true, Category = category };
            }
            catch (Exception ex)
            {
                return new ResultCategoryDto { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public ResultCategoryDto UpdateCategory(Category category)
        {
            try
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return new ResultCategoryDto { Success = true, Category = category };
            }
            catch (Exception ex)
            {
                return new ResultCategoryDto { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public ResultCategoryDto GetCategoryById(long id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                return new ResultCategoryDto { Success = true, Category = category };
            }
            else
            {
                return new ResultCategoryDto { Success = false, Errors = new List<string> { "Category not found" } };
            }
        }

        public ResultCategoryDto DeleteCategoryById(long id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                try
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    return new ResultCategoryDto { Success = true };
                }
                catch (Exception ex)
                {
                    return new ResultCategoryDto { Success = false, Errors = new List<string> { ex.Message } };
                }
            }
            else
            {
                return new ResultCategoryDto { Success = false, Errors = new List<string> { "Category not found" } };
            }
        }
    }
}
