using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductsAPI.Controllers.v1.OrderControllers
{
    [ApiController]
    [Route("api/v1/orders")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Orders")]
    public class PutOrderController : OrderBaseController
    {
        public PutOrderController(IOrderService orderService) : base(orderService)
        {
        }

        // PUT: api/v1/orders/{id}
        [SwaggerOperation(Summary = "Update an existing order", Description = "Modifies the details of an existing order.")]
        [SwaggerResponse(200, "Order updated successfully.", typeof(OrderDTO))]
        [SwaggerResponse(404, "Order not found.")]
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