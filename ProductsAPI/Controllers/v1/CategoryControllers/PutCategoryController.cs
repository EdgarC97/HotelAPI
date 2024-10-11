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
    public class PutCategoryController : CategoryBaseController
    {
        public PutCategoryController(ICategoryService categoryService) : base(categoryService)
        {
        }

        // PUT: api/v1/categories/{id}
        [SwaggerOperation(Summary = "Update an existing category", Description = "Modifies the details of an existing category.")]
        [SwaggerResponse(200, "Category updated successfully.", typeof(CategoryDTO))]
        [SwaggerResponse(404, "Category not found.")]
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, [FromBody] UpdateCategoryDTO updateCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (isSuccess, updatedCategory, message) = await _categoryService.UpdateCategoryAsync(id, updateCategoryDto);
            if (!isSuccess)
            {
                return NotFound(new { message });
            }

            return Ok(new
            {
                message,
                data = updatedCategory
            });
        }
    }
}