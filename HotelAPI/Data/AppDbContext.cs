using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Models;
using HotelAPI.Seeders;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data
{
    // DbContext class representing the database context for the Hotel API.
    public class AppDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions for configuring the context.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet properties for each entity in the database.
        public DbSet<RoomType> RoomTypes { get; set; }
        
        public DbSet<Room> Rooms { get; set; }
        
        public DbSet<Guest> Guests { get; set; }
        
        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<Booking> Bookings { get; set; }

        // Method called when the model for a derived context is being created.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the database with initial data for RoomTypes, Rooms, Guests, Employees, and Bookings.
            RoomTypeSeeder.Seed(modelBuilder);
            RoomSeeder.Seed(modelBuilder);
            GuestSeeder.Seed(modelBuilder);
            EmployeeSeeder.Seed(modelBuilder);
            BookingSeeder.Seed(modelBuilder);

            // Call the base class implementation.
            base.OnModelCreating(modelBuilder);
        }
    }
}