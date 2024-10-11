using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

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

        // GET: api/v1/categories
        [SwaggerOperation(Summary = "Get all categories", Description = "Retrieves a list of all categories in the system.")]
        [SwaggerResponse(200, "Returns a list of categories.", typeof(IEnumerable<CategoryDTO>))]
        [SwaggerResponse(204, "No categories found.")]
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

        // GET: api/v1/categories/{id}
        [SwaggerOperation(Summary = "Get category by ID", Description = "Retrieves a specific category by its ID.")]
        [SwaggerResponse(200, "Returns the requested category.", typeof(CategoryDTO))]
        [SwaggerResponse(404, "Category not found.")]
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