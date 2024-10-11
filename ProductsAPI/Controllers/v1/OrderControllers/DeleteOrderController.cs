using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductsAPI.Controllers.v1.OrderControllers
{
    [ApiController]
    [Route("api/v1/orders")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class DeleteOrderController : OrderBaseController
    {
        public DeleteOrderController(IOrderService orderService) : base(orderService)
        {
        }

        // DELETE: api/v1/orders/{id}
        [SwaggerOperation(Summary = "Delete an order by ID", Description = "Removes the specified order from the system.")]
        [SwaggerResponse(200, "Order deleted successfully.")]
        [SwaggerResponse(404, "Order not found.")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    message = "Order deleted successfully."
                });
            }

            return NotFound(result.Message);
        }
    }
}