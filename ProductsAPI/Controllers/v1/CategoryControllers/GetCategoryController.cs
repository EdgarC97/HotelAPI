using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers.v1.CategoryControllers
{
    [ApiController]
    [Route("api/v1/categories")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GetCategoryController : CategoryBaseController
    {
        public GetCategoryController(ICategoryService categoryService) : base(categoryService)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
        {
            var (categories, message) = await _categoryService.GetAllCategoriesAsync();
            if (categories == null)
            {
                return NotFound(new { message });
            }
            return Ok(new { message, data = categories });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var (category, message) = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound(new { message });
            }
            return Ok(new { message, data = category });
        }
    }
}