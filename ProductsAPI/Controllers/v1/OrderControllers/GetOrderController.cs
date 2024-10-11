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
    public class GetOrderController : OrderBaseController
    {
        public GetOrderController(IOrderService orderService) : base(orderService)
        {
        }

        // GET: api/v1/orders
        [SwaggerOperation(Summary = "Get all orders", Description = "Retrieves a list of all orders in the system.")]
        [SwaggerResponse(200, "Returns a list of orders.", typeof(IEnumerable<OrderDTO>))]
        [SwaggerResponse(204, "No orders found.")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var (orders, message) = await _orderService.GetAllOrdersAsync();
            if (orders == null)
            {
                return NotFound(message);
            }
            return Ok(orders);
        }

        // GET: api/v1/orders/{id}
        [SwaggerOperation(Summary = "Get order by ID", Description = "Retrieves a specific order by its ID.")]
        [SwaggerResponse(200, "Returns the requested order.", typeof(OrderDTO))]
        [SwaggerResponse(404, "Order not found.")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var (order, message) = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound(message);
            }
            return Ok(order);
        }

        // GET: api/v1/orders/customer/{customerName}
        [SwaggerOperation(Summary = "Get orders by customer name", Description = "Retrieves all orders placed by a specific customer.")]
        [SwaggerResponse(200, "Returns a list of orders for the customer.", typeof(IEnumerable<OrderDTO>))]
        [SwaggerResponse(404, "No orders found for the specified customer.")]
        [HttpGet("customer/{customerName}")]
        public async Task<ActionResult<List<OrderDTO>>> GetOrdersByCustomerName(string customerName)
        {
            var (orders, message) = await _orderService.GetOrdersByCustomerNameAsync(customerName);
            if (orders == null)
            {
                return NotFound(new { message });
            }
            return Ok(new { message, data = orders });
        }
        // GET: api/v1/orders/date/{date}
        [SwaggerOperation(Summary = "Get orders by date", Description = "Retrieves all orders placed on a specific date. Please fill with format YYYY-MM-DD")]
        [SwaggerResponse(200, "Returns a list of orders for the specified date.", typeof(IEnumerable<OrderDTO>))]
        [SwaggerResponse(404, "No orders found for the specified date.")]
        [HttpGet("date/{date}")]
        public async Task<ActionResult<List<OrderDTO>>> GetOrdersByDate(DateTime date)
        {
            var (orders, message) = await _orderService.GetOrdersByDateAsync(date);
            if (orders == null)
            {
                return NotFound(new { message });
            }
            return Ok(new { message, data = orders });
        }
    }
}