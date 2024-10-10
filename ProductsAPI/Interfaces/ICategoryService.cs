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
    }
}