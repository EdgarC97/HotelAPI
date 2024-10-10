using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAPI.DTOS;

namespace ProductsAPI.Interfaces
{
    public interface ICategoryService
    {
        Task<(List<CategoryDTO> categories, string message)> GetAllCategoriesAsync();
        Task<(CategoryDTO category, string message)> GetCategoryByIdAsync(int id);

        // Asynchronously creates a new category and returns a tuple indicating success, the created CategoryDTO, and a message.
        Task<(bool IsSuccess, CategoryDTO Category, string Message)> CreateCategoryAsync(CreateCategoryDTO createCategoryDto);

        // Asynchronously deletes a category by its ID and returns a tuple indicating success and a message.
        Task<(bool IsSuccess, string Message)> DeleteCategoryAsync(int id);

        Task<(bool IsSuccess, CategoryDTO Category, string Message)> UpdateCategoryAsync(int id, UpdateCategoryDTO updateCategoryDto);
    }
}