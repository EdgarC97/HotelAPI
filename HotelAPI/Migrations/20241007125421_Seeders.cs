using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seeders : Migration
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

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Birthdate", "Email", "FirstName", "IdentificationNumber", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "juan.perez@example.com", "Juan", "ID123456", "Pérez", null },
                    { 2, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.lopez@example.com", "María", "ID234567", "López", null },
                    { 3, new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos.garcia@example.com", "Carlos", "ID345678", "García", null },
                    { 4, new DateTime(1988, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana.martinez@example.com", "Ana", "ID456789", "Martínez", null }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Una acogedora habitación básica con una cama individual, ideal para viajeros solos.", "Habitación Simple" },
                    { 2, "Ofrece flexibilidad con dos camas individuales o una cama doble, perfecta para parejas o amigos.", "Habitación Doble" },
                    { 3, "Espaciosa y lujosa, con una cama king size y una sala de estar separada, ideal para quienes buscan confort y exclusividad.", "Suite" },
                    { 4, "Diseñada para familias, con espacio adicional y varias camas para una estancia cómoda.", "Habitación Familiar" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Availability", "MaxOccupancyPersons", "PricePerNight", "RoomNumber", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, true, 1, 50m, "1-1", 1 },
                    { 2, true, 2, 80m, "1-2", 2 },
                    { 3, true, 2, 150m, "1-3", 3 },
                    { 4, true, 4, 200m, "1-4", 4 },
                    { 5, true, 1, 50m, "1-5", 1 },
                    { 6, true, 1, 50m, "1-6", 1 },
                    { 7, true, 1, 50m, "1-7", 1 },
                    { 8, true, 1, 50m, "1-8", 1 },
                    { 9, true, 1, 50m, "1-9", 1 },
                    { 10, true, 1, 50m, "1-10", 1 },
                    { 11, true, 1, 50m, "2-1", 1 },
                    { 12, true, 2, 80m, "2-2", 2 },
                    { 13, true, 2, 150m, "2-3", 3 },
                    { 14, true, 4, 200m, "2-4", 4 },
                    { 15, true, 1, 50m, "2-5", 1 },
                    { 16, true, 1, 50m, "2-6", 1 },
                    { 17, true, 1, 50m, "2-7", 1 },
                    { 18, true, 1, 50m, "2-8", 1 },
                    { 19, true, 1, 50m, "2-9", 1 },
                    { 20, true, 1, 50m, "2-10", 1 },
                    { 21, true, 1, 50m, "3-1", 1 },
                    { 22, true, 2, 80m, "3-2", 2 },
                    { 23, true, 2, 150m, "3-3", 3 },
                    { 24, true, 4, 200m, "3-4", 4 },
                    { 25, true, 1, 50m, "3-5", 1 },
                    { 26, true, 1, 50m, "3-6", 1 },
                    { 27, true, 1, 50m, "3-7", 1 },
                    { 28, true, 1, 50m, "3-8", 1 },
                    { 29, true, 1, 50m, "3-9", 1 },
                    { 30, true, 1, 50m, "3-10", 1 },
                    { 31, true, 1, 50m, "4-1", 1 },
                    { 32, true, 2, 80m, "4-2", 2 },
                    { 33, true, 2, 150m, "4-3", 3 },
                    { 34, true, 4, 200m, "4-4", 4 },
                    { 35, true, 1, 50m, "4-5", 1 },
                    { 36, true, 1, 50m, "4-6", 1 },
                    { 37, true, 1, 50m, "4-7", 1 },
                    { 38, true, 1, 50m, "4-8", 1 },
                    { 39, true, 1, 50m, "4-9", 1 },
                    { 40, true, 1, 50m, "4-10", 1 },
                    { 41, true, 1, 50m, "5-1", 1 },
                    { 42, true, 2, 80m, "5-2", 2 },
                    { 43, true, 2, 150m, "5-3", 3 },
                    { 44, true, 4, 200m, "5-4", 4 },
                    { 45, true, 1, 50m, "5-5", 1 },
                    { 46, true, 1, 50m, "5-6", 1 },
                    { 47, true, 1, 50m, "5-7", 1 },
                    { 48, true, 1, 50m, "5-8", 1 },
                    { 49, true, 1, 50m, "5-9", 1 },
                    { 50, true, 1, 50m, "5-10", 1 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "EmployeeId", "EndDate", "GuestId", "RoomId", "StartDate", "TotalCost" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m },
                    { 2, 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 560m },
                    { 3, 2, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300m },
                    { 4, 2, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 800m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
