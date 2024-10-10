using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;

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