using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.v1.BookingControllers
{
    /// <summary>
    /// API controller for retrieving booking-related actions.
    /// </summary>
    [ApiController]
    [Route("api/v1/bookings")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GetBookingController : BookingBaseController
    {
        public GetBookingController(IBookingService bookingService) : base(bookingService) { }

        /// <summary>
        /// Retrieves a booking by its ID.
        /// </summary>
        /// <param name="id">The ID of the booking to retrieve.</param>
        /// <returns>An IActionResult containing the booking details.</returns>
        /// <response code="200">Returns the booking details if found.</response>
        /// <response code="404">Returns an error message if the booking is not found.</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound("Booking not found.");
            }

            return Ok(new
            {
                message = "Booking details",
                data = booking
            });
        }
    }
}
