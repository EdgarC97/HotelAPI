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
    public class PutOrderController : OrderBaseController
    {
        public PutOrderController(IOrderService orderService) : base(orderService)
        {
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> UpdateOrder(int id, [FromBody] UpdateOrderDTO updateOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (isSuccess, updatedOrder, message) = await _orderService.UpdateOrderAsync(id, updateOrderDto);
            if (!isSuccess)
            {
                return NotFound(new { message });
            }

            return Ok(new
            {
                message,
                data = updatedOrder
            });
        }
    }
}