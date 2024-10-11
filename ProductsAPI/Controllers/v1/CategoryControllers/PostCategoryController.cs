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
    public class PostCategoryController : CategoryBaseController
    {
        public PostCategoryController(ICategoryService categoryService) : base(categoryService)
        {
        }

        // POST: api/v1/categories
        [SwaggerOperation(Summary = "Create a new category", Description = "Adds a new category to the system.")]
        [SwaggerResponse(200, "Category created successfully.", typeof(CategoryDTO))]
        [SwaggerResponse(400, "Invalid category details.")]
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] CreateCategoryDTO createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _categoryService.CreateCategoryAsync(createCategoryDto);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    message = "Category created successfully",
                    data = result.Category
                });
            }

            return BadRequest(result.Message);
        }
    }
}