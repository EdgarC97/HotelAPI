using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers.v1.OrderControllers
{
    [ApiController]
    [Route("api/v1/orders")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PostOrderController : OrderBaseController
    {
        public PostOrderController(IOrderService orderService) : base(orderService)
        {
        }

        // POST: api/v1/orders
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder([FromBody] CreateOrderDTO createOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _orderService.CreateOrderAsync(createOrderDto);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    message = "Order created successfully",
                    data = result.Order
                });
            }

            return BadRequest(result.Message);
        }
    }
}
