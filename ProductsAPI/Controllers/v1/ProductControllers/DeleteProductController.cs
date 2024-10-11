using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductsAPI.Controllers.v1.ProductControllers
{
    [ApiController]
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class DeleteProductController : ProductBaseController
    {
        public DeleteProductController(IProductService productService) : base(productService)
        {
        }

        // DELETE: api/v1/products/{id}
        [SwaggerOperation(Summary = "Delete a product by ID", Description = "Removes the specified product from the system.")]
        [SwaggerResponse(200, "Product deleted successfully.")]
        [SwaggerResponse(404, "Product not found.")]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    message = "Product deleted successfully."
                });
            }

            return NotFound(result.Message);
        }
    }
}