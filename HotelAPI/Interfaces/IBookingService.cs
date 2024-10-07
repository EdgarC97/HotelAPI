using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.DTOS;

namespace HotelAPI.Interfaces
{
    // Interface for the booking service that defines methods for managing bookings.
    public interface IBookingService
    {
        // Asynchronously retrieves a booking by its ID and returns the corresponding BookingDTO.
        Task<BookingDTO> GetBookingByIdAsync(int id);

        // Asynchronously creates a new booking and returns a tuple indicating success, the created BookingDTO, and a message.
        Task<(bool IsSuccess, BookingDTO Booking, string Message)> CreateBookingAsync(CreateBookingDTO createBookingDto);

        // Asynchronously deletes a booking by its ID and returns a tuple indicating success and a message.
        Task<(bool IsSuccess, string Message)> DeleteBookingAsync(int id);
    }
}
