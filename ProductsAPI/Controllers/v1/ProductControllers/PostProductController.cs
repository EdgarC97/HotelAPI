using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers.v1.ProductControllers
{
    [ApiController]
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PostProductController : ProductBaseController
    {
        public PostProductController(IProductService productService) : base(productService)
        {
        }

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