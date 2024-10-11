using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductsAPI.Controllers.v1.CategoryControllers
{
    [ApiController]
    [Route("api/v1/categories")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class DeleteCategoryController : CategoryBaseController
    {
        public DeleteCategoryController(ICategoryService categoryService) : base(categoryService)
        {
        }

        // DELETE: api/v1/categories/{id}
        [SwaggerOperation(Summary = "Delete a category by ID", Description = "Removes the specified category from the system.")]
        [SwaggerResponse(200, "Category deleted successfully.")]
        [SwaggerResponse(404, "Category not found.")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    message = "Category deleted successfully."
                });
            }

            return NotFound(result.Message);
        }

    }
}