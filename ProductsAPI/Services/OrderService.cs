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
                        Quantity = op.Quantity,
                        Price = _context.Products
                            .Where(p => p.Id == op.ProductId)
                            .Select(p => p.Price)
                            .FirstOrDefault()
                    }).ToList(),
                    TotalPrice = o.OrderProducts.Sum(op =>
                        _context.Products
                            .Where(p => p.Id == op.ProductId)
                            .Select(p => p.Price)
                            .FirstOrDefault() * op.Quantity 
                    )
                })
                .ToListAsync();

            if (orders == null || orders.Count == 0)
            {
                return (null, "No orders found. Please check back later!");
            }

            
            string message = $"Orders retrieved successfully! Total Order: {orders.Sum(o => o.TotalPrice):C}";

            return (orders, message); 
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
                OrderProducts = new List<OrderProduct>() // Initialize the list
            };

            // Loop through each product in the order
            foreach (var orderProductDto in createOrderDto.OrderProducts)
            {
                var product = await _context.Products.FindAsync(orderProductDto.ProductId);

                // Check if the product exists
                if (product == null)
                {
                    return (false, null, $"Product with ID {orderProductDto.ProductId} not found.");
                }

                // Check if there is enough stock
                if (product.Stock < orderProductDto.Quantity)
                {
                    return (false, null, $"Not enough stock for product {product.Name}.");
                }

                // Reduce stock
                product.Stock -= orderProductDto.Quantity;

                // Add product to the order
                order.OrderProducts.Add(new OrderProduct
                {
                    ProductId = orderProductDto.ProductId,
                    Quantity = orderProductDto.Quantity
                });
            }

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
            var order = await _context.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.Id == id); // Find the order by ID.

            if (order == null)
            {
                return (false, null, "Order not found."); // Return failure if the order is not found.
            }

            // First, restore stock for the existing products in the order
            foreach (var existingProduct in order.OrderProducts)
            {
                var product = await _context.Products.FindAsync(existingProduct.ProductId);
                if (product != null)
                {
                    product.Stock += existingProduct.Quantity; // Restore stock
                }
            }

            // Update the order properties with the new values from the DTO.
            order.OrderDate = updateOrderDto.OrderDate;
            order.CustomerName = updateOrderDto.CustomerName;
            order.CustomerAddress = updateOrderDto.CustomerAddress;
            order.CustomerContact = updateOrderDto.CustomerContact;

            // Clear the existing products to prepare for the new set
            order.OrderProducts.Clear();

            // Update or add products to the order
            foreach (var orderProductDto in updateOrderDto.OrderProducts)
            {
                var product = await _context.Products.FindAsync(orderProductDto.ProductId);

                // Check if the product exists
                if (product == null)
                {
                    return (false, null, $"Product with ID {orderProductDto.ProductId} not found.");
                }

                // Check if there is enough stock
                if (product.Stock < orderProductDto.Quantity)
                {
                    return (false, null, $"Not enough stock for product {product.Name}.");
                }

                // Reduce stock for the new quantity
                product.Stock -= orderProductDto.Quantity;

                // Add the product to the order
                order.OrderProducts.Add(new OrderProduct
                {
                    ProductId = orderProductDto.ProductId,
                    Quantity = orderProductDto.Quantity
                });
            }

            // Save changes to the database.
            await _context.SaveChangesAsync();

            // Map the updated Order entity to OrderDTO for the response.
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

            return (true, orderDto, "Order updated successfully.");
        }

        public async Task<(List<OrderDTO> orders, string message)> GetOrdersByCustomerNameAsync(string customerName)
        {
            var orders = await _context.Orders
                .Where(o => o.CustomerName.Contains(customerName))
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
                return (null, $"No orders found for customer: {customerName}");
            }

            return (orders, "Orders retrieved successfully!");
        }

        public async Task<(List<OrderDTO> orders, string message)> GetOrdersByDateAsync(DateTime date)
        {
            var orders = await _context.Orders
                .Where(o => o.OrderDate.Date == date.Date)
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
                return (null, $"No orders found for date: {date.ToShortDateString()}");
            }

            return (orders, "Orders retrieved successfully!");
        }
    }

}

