using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductsAPI.Controllers.v1.ProductControllers
{
    [ApiController]
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PutProductController : ProductBaseController
    {
        public PutProductController(IProductService productService) : base(productService)
        {
        }

        // PUT: api/v1/products/{id}
        [SwaggerOperation(Summary = "Update an existing product", Description = "Modifies the details of an existing product.")]
        [SwaggerResponse(200, "Product updated successfully.", typeof(ProductDTO))]
        [SwaggerResponse(404, "Product not found.")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, [FromBody] UpdateProductDTO updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (isSuccess, updatedProduct, message) = await _productService.UpdateProductAsync(id, updateProductDto);
            if (!isSuccess)
            {
                return NotFound(new { message });
            }

            return Ok(new
            {
                message,
                data = updatedProduct
            });
        }

    }
}