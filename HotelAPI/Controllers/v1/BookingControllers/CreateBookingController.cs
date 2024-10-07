using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.DTOS;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.v1.BookingControllers
{
    /// <summary>
    /// API controller for creating booking-related actions.
    /// </summary>
    [ApiController]
    [Route("api/v1/bookings")]
    public class CreateBookingController : BookingBaseController
    {
        public CreateBookingController(IBookingService bookingService) : base(bookingService) { }

        /// <summary>
        /// Creates a new booking.
        /// </summary>
        /// <param name="createBookingDto">The data transfer object containing the booking information.</param>
        /// <returns>An ActionResult containing the created booking information.</returns>
        /// <response code="200">Returns the created booking.</response>
        /// <response code="400">Returns an error message if the model state is invalid or booking creation fails.</response>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BookingDTO>> CreateBooking([FromBody] CreateBookingDTO createBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _bookingService.CreateBookingAsync(createBookingDto);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    message = "Booking created successfully",
                    data = result.Booking
                });
            }

            return BadRequest(result.Message);
        }
    }
}