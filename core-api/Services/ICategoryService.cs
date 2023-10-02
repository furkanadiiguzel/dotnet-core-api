using System.Collections.Generic;
using core_api.Models; // Replace with your actual model namespace

namespace core_api.Services
{
    public interface ICategoryService
    {
        ResultCategoryDto AddCategory(Category category);

        ResultCategoryDto UpdateCategory(Category category);

        List<Category> GetCategories();

        ResultCategoryDto GetCategoryById(long id);

        ResultCategoryDto DeleteCategoryById(long id);
    }
}
