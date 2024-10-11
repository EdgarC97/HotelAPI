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
    [Tags("Products")]
    public class PostProductController : ProductBaseController
    {
        public PostProductController(IProductService productService) : base(productService)
        {
        }

        // POST: api/v1/products
        [SwaggerOperation(Summary = "Create a new product", Description = "Adds a new product to the system.")]
        [SwaggerResponse(200, "Product created successfully.", typeof(ProductDTO))]
        [SwaggerResponse(400, "Invalid product details.")]
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] CreateProductDTO createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.CreateProductAsync(createProductDto);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    message = "Product created successfully",
                    data = result.Product
                });
            }

            return BadRequest(result.Message);
        }
    }
}