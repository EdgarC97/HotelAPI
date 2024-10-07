using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Seeders
{
    public class BookingSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, RoomId = 1, GuestId = 1, EmployeeId = 1, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 5), TotalCost = 200m },
                new Booking { Id = 2, RoomId = 2, GuestId = 2, EmployeeId = 1, StartDate = new DateTime(2024, 1, 3), EndDate = new DateTime(2024, 1, 10), TotalCost = 560m },
                new Booking { Id = 3, RoomId = 3, GuestId = 3, EmployeeId = 2, StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2024, 2, 3), TotalCost = 300m },
                new Booking { Id = 4, RoomId = 4, GuestId = 4, EmployeeId = 2, StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 3, 5), TotalCost = 800m }
            );
        }
    }
}