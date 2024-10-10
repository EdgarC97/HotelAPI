using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(List<OrderDTO> orders, string message)> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    CustomerName = o.CustomerName,
                    CustomerAddress = o.CustomerAddress,
                    CustomerContact = o.CustomerContact,
                    OrderProducts = o.OrderProducts.Select(op => new OrderProductDTO
                    {
                        ProductId = op.ProductId,
                        Quantity = op.Quantity
                    }).ToList()
                })
                .ToListAsync();

            if (orders == null || orders.Count == 0)
            {
                return (null, "No orders found. Please check back later!");
            }

            return (orders, "Orders retrieved successfully!");
        }

        public async Task<(OrderDTO order, string message)> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    CustomerName = o.CustomerName,
                    CustomerAddress = o.CustomerAddress,
                    CustomerContact = o.CustomerContact,
                    OrderProducts = o.OrderProducts.Select(op => new OrderProductDTO
                    {
                        ProductId = op.ProductId,
                        Quantity = op.Quantity
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return (null, $"Order with ID {id} not found. Please check the ID and try again.");
            }

            return (order, "Order retrieved successfully!");
        }

        public async Task<(bool IsSuccess, OrderDTO Order, string Message)> CreateOrderAsync(CreateOrderDTO createOrderDto)
        {
            // Validate input data
            if (string.IsNullOrWhiteSpace(createOrderDto.CustomerName))
            {
                return (false, null, "Customer name is required.");
            }

            // Create a new Order entity from the provided DTO.
            var order = new Order
            {
                OrderDate = createOrderDto.OrderDate,
                CustomerName = createOrderDto.CustomerName,
                CustomerAddress = createOrderDto.CustomerAddress,
                CustomerContact = createOrderDto.CustomerContact,
                OrderProducts = createOrderDto.OrderProducts.Select(op => new OrderProduct
                {
                    ProductId = op.ProductId,
                    Quantity = op.Quantity
                }).ToList()
            };

            // Add the new order to the context and save changes to the database.
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Map the new Order entity to OrderDTO for the response.
            var orderDto = new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                CustomerName = order.CustomerName,
                CustomerAddress = order.CustomerAddress,
                CustomerContact = order.CustomerContact,
                OrderProducts = order.OrderProducts.Select(op => new OrderProductDTO
                {
                    ProductId = op.ProductId,
                    Quantity = op.Quantity
                }).ToList()
            };

            return (true, orderDto, "Order created successfully."); // Return success result.
        }

        public async Task<(bool IsSuccess, string Message)> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return (false, "Order not found.");
            }

            // Remove the order from the context and save changes to the database.
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return (true, "Order deleted successfully.");
        }

        public async Task<(bool IsSuccess, OrderDTO Order, string Message)> UpdateOrderAsync(int id, UpdateOrderDTO updateOrderDto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return (false, null, "Order not found.");
            }

            // Actualiza las propiedades del pedido
            order.CustomerName = updateOrderDto.CustomerName;
            order.CustomerAddress = updateOrderDto.CustomerAddress;
            order.CustomerContact = updateOrderDto.CustomerContact;

            await _context.SaveChangesAsync();

            var orderDto = new OrderDTO
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                CustomerAddress = order.CustomerAddress,
                CustomerContact = order.CustomerContact
            };

            return (true, orderDto, "Order updated successfully.");
        }

    }
}