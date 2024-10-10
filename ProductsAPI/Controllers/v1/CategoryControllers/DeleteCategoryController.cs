using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;

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