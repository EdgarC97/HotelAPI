using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsAPI.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "IdentificationNumber", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "luis.fernandez@example.com", "Luis", "EMP123456", "Fernández", "hashed_password_1" },
                    { 2, "clara.torres@example.com", "Clara", "EMP234567", "Torres", "hashed_password_2" },
                    { 3, "javier.ramirez@example.com", "Javier", "EMP345678", "Ramírez", "hashed_password_3" },
                    { 4, "elena.sanchez@example.com", "Elena", "EMP456789", "Sánchez", "hashed_password_4" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 11, 9, 8, 44, 903, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 10, 11, 9, 8, 44, 903, DateTimeKind.Local).AddTicks(1488));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 11, 9, 6, 45, 17, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 10, 11, 9, 6, 45, 17, DateTimeKind.Local).AddTicks(518));
        }
    }
}
