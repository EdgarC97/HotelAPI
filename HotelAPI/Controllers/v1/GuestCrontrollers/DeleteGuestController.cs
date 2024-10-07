using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.v1.GuestCrontrollers
{
    /// <summary>
    /// API controller for managing guest-related actions, including deletion of guests.
    /// </summary>
    [ApiController]
    [Route("api/v1/guests")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class DeleteGuestController : GuestBaseController
    {
        public DeleteGuestController(IGuestService guestService) : base(guestService)
        {
        }

        /// <summary>
        /// Deletes a guest by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the guest to be deleted.</param>
        /// <returns>An IActionResult indicating the outcome of the delete operation.</returns>
        /// <response code="200">Returns a success message if the guest is deleted.</response>
        /// <response code="404">Returns an error message if the guest is not found.</response>
        // DELETE: api/v1/guests/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            // Attempt to delete the guest using the guest service
            var result = await _guestService.DeleteGuestAsync(id);
            if (!result)
            {
                // If the guest was not found, return a 404 Not Found response
                return NotFound("Guest not found");
            }

            // If deletion was successful, return a 200 OK response with a success message
            return Ok(new
            {
                message = "¡Guest deleted successfully!"
            });
        }
    }
}