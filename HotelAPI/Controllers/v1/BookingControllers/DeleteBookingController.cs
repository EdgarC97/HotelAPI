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
    /// API controller for deleting booking-related actions.
    /// </summary>
    [ApiController]
    [Route("api/v1/bookings")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class DeleteBookingController : BookingBaseController
    {
        public DeleteBookingController(IBookingService bookingService) : base(bookingService) { }

        /// <summary>
        /// Deletes a booking by its ID.
        /// </summary>
        /// <param name="id">The ID of the booking to delete.</param>
        /// <returns>An IActionResult indicating the result of the delete operation.</returns>
        /// <response code="200">Returns a success message if the booking was deleted successfully.</response>
        /// <response code="404">Returns an error message if the booking is not found.</response>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    message = "Booking deleted successfully."
                });
            }

            return NotFound(result.Message);
        }
    }
}
