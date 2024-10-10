using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Devices and gadgets", "Electronics" },
                    { 2, "Apparel and accessories", "Clothing" },
                    { 3, "Home appliances and kitchenware", "Home & Kitchen" },
                    { 4, "Sporting goods and equipment", "Sports" },
                    { 5, "Literature and reading material", "Books" },
                    { 6, "Children's toys and games", "Toys" },
                    { 7, "Car parts and accessories", "Automotive" },
                    { 8, "Health products and cosmetics", "Health & Beauty" },
                    { 9, "Stationery and office equipment", "Office Supplies" },
                    { 10, "Products for pets", "Pet Supplies" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerAddress", "CustomerContact", "CustomerName", "OrderDate" },
                values: new object[,]
                {
                    { 1, "123 Elm St", "555-1234", "John Doe", new DateTime(2024, 10, 10, 9, 53, 12, 631, DateTimeKind.Local).AddTicks(7909) },
                    { 2, "456 Oak St", "555-5678", "Jane Smith", new DateTime(2024, 10, 10, 9, 53, 12, 631, DateTimeKind.Local).AddTicks(7942) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Latest model smartphone", "Smartphone", 699.99m, 50 },
                    { 2, 1, "Powerful laptop for work and play", "Laptop", 999.99m, 30 },
                    { 3, 2, "Comfortable denim jeans", "Jeans", 49.99m, 100 },
                    { 4, 3, "High-speed blender", "Blender", 89.99m, 20 },
                    { 5, 4, "Durable basketball", "Basketball", 29.99m, 150 },
                    { 6, 5, "Bestselling fiction book", "Fiction Novel", 19.99m, 200 },
                    { 7, 6, "Collectible action figure", "Action Figure", 14.99m, 75 },
                    { 8, 7, "Reliable car battery", "Car Battery", 129.99m, 25 },
                    { 9, 8, "Hydrating face cream", "Face Cream", 24.99m, 40 },
                    { 10, 9, "Ergonomic office chair", "Office Chair", 199.99m, 15 }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 3, 2 },
                    { 3, 2, 4, 1 },
                    { 4, 2, 5, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
