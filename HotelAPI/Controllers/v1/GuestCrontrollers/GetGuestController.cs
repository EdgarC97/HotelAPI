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
    /// API controller for managing guest-related actions, including retrieval of guests.
    /// </summary>
    [ApiController]
    [Route("api/v1/guests")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GetGuestController : GuestBaseController
    {
        public GetGuestController(IGuestService guestService) : base(guestService) { }

        /// <summary>
        /// Retrieves a list of all registered guests.
        /// </summary>
        /// <returns>An IActionResult containing a list of guests.</returns>
        /// <response code="200">Returns a list of registered guests.</response>
        // GET: api/v1/guests
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllGuests()
        {
            // Retrieve all guests using the guest service
            var guests = await _guestService.GetAllGuestsAsync();
            return Ok(new
            {
                message = "List of registered guests",
                data = guests
            });
        }

        /// <summary>
        /// Retrieves details of a specific guest by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the guest to retrieve.</param>
        /// <returns>An IActionResult containing the guest details.</returns>
        /// <response code="200">Returns the details of the specified guest.</response>
        /// <response code="404">Returns an error message if the guest is not found.</response>
        // GET: api/v1/guests/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetGuestById(int id)
        {
            // Retrieve the guest by ID using the guest service
            var guest = await _guestService.GetGuestByIdAsync(id);
            if (guest == null)
            {
                // If the guest was not found, return a 404 Not Found response
                return NotFound("Guest not found");
            }

            // Return the guest details with a 200 OK response
            return Ok(new
            {
                message = "Guest details",
                data = guest
            });
        }
    }
}