using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Models;
using HotelAPI.Seeders;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoomTypeSeeder.Seed(modelBuilder);
            RoomSeeder.Seed(modelBuilder);
            GuestSeeder.Seed(modelBuilder);
            EmployeeSeeder.Seed(modelBuilder);
            BookingSeeder.Seed(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }
    }
}