using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;

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

        [HttpDelete("{id}")]
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