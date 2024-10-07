using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.DTOS;

namespace HotelAPI.Interfaces
{
    // Interface for the guest service that defines methods for managing guests.
    public interface IGuestService
    {
        // Asynchronously retrieves a collection of all guests and returns them as a list of GuestDTO.
        Task<IEnumerable<GuestDTO>> GetAllGuestsAsync();

        // Asynchronously retrieves a guest by their ID and returns the corresponding GuestDTO.
        Task<GuestDTO> GetGuestByIdAsync(int id);

        // Asynchronously deletes a guest by their ID and returns a boolean indicating success.
        Task<bool> DeleteGuestAsync(int id);
    }
}
