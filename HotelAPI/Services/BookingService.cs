using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Data;
using HotelAPI.DTOS;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    // Service class that implements booking-related operations.
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context; // Database context for accessing booking data.

        // Constructor that initializes the BookingService with the required dependencies.
        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        // Asynchronously retrieves a booking by its ID, including related Room, Guest, and Employee entities.
        public async Task<BookingDTO> GetBookingByIdAsync(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Room) // Include related Room data.
                .Include(b => b.Guest) // Include related Guest data.
                .Include(b => b.Employee) // Include related Employee data.
                .FirstOrDefaultAsync(b => b.Id == id); // Find the booking by ID.

            if (booking == null)
            {
                return null; // Return null if no booking is found.
            }

            // Map the Booking entity to BookingDTO for the response.
            return new BookingDTO
            {
                Id = booking.Id,
                RoomId = booking.RoomId,
                GuestId = booking.GuestId,
                EmployeeId = booking.EmployeeId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                TotalCost = booking.TotalCost
            };
        }

        // Asynchronously creates a new booking based on the provided CreateBookingDTO.
        public async Task<(bool IsSuccess, BookingDTO Booking, string Message)> CreateBookingAsync(CreateBookingDTO createBookingDto)
        {
            // Validate the input data for the booking.
            if (createBookingDto.RoomId <= 0)
            {
                return (false, null, "Invalid room ID.");
            }
            if (createBookingDto.GuestId <= 0)
            {
                return (false, null, "Invalid guest ID.");
            }
            if (createBookingDto.EmployeeId <= 0)
            {
                return (false, null, "Invalid employee ID.");
            }
            if (createBookingDto.StartDate >= createBookingDto.EndDate)
            {
                return (false, null, "Start date must be earlier than end date.");
            }
            if (createBookingDto.TotalCost < 0)
            {
                return (false, null, "Total cost cannot be negative.");
            }

            // Create a new Booking entity from the provided DTO.
            var booking = new Booking
            {
                RoomId = createBookingDto.RoomId,
                GuestId = createBookingDto.GuestId,
                EmployeeId = createBookingDto.EmployeeId,
                StartDate = createBookingDto.StartDate,
                EndDate = createBookingDto.EndDate,
                TotalCost = createBookingDto.TotalCost
            };

            // Add the new booking to the context and save changes to the database.
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Map the new Booking entity to BookingDTO for the response.
            var bookingDto = new BookingDTO
            {
                Id = booking.Id,
                RoomId = booking.RoomId,
                GuestId = booking.GuestId,
                EmployeeId = booking.EmployeeId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                TotalCost = booking.TotalCost
            };

            return (true, bookingDto, "Booking created successfully."); // Return success result.
        }

        // Asynchronously deletes a booking by its ID.
        public async Task<(bool IsSuccess, string Message)> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id); // Find the booking by ID.
            if (booking == null)
            {
                return (false, "Booking not found."); // Return failure if booking is not found.
            }

            // Remove the booking from the context and save changes to the database.
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return (true, "Booking deleted successfully."); // Return success result.
        }
    }
}

