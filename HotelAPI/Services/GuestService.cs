using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Data;
using HotelAPI.DTOS;
using HotelAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    // Service class that implements guest-related operations.
    public class GuestService : IGuestService
    {
        private readonly AppDbContext _context; // Database context for accessing guest data.

        // Constructor that initializes the GuestService with the required dependencies.
        public GuestService(AppDbContext context)
        {
            _context = context; // Assign the database context.
        }

        // Asynchronously retrieves all guests from the database and maps them to GuestDTO objects.
        public async Task<IEnumerable<GuestDTO>> GetAllGuestsAsync()
        {
            return await _context.Guests
                .Select(g => new GuestDTO
                {
                    Id = g.Id,
                    FirstName = g.FirstName,
                    LastName = g.LastName,
                    Email = g.Email,
                    IdentificationNumber = g.IdentificationNumber,
                    PhoneNumber = g.PhoneNumber,
                    Birthdate = g.Birthdate
                }).ToListAsync(); // Convert to a list asynchronously.
        }

        // Asynchronously retrieves a guest by their ID and maps the data to a GuestDTO object.
        public async Task<GuestDTO> GetGuestByIdAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id); // Find the guest by ID.
            if (guest == null) return null; // Return null if no guest is found.

            // Map the Guest entity to GuestDTO for the response.
            return new GuestDTO
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                IdentificationNumber = guest.IdentificationNumber,
                PhoneNumber = guest.PhoneNumber,
                Birthdate = guest.Birthdate
            };
        }

        // Asynchronously deletes a guest by their ID.
        public async Task<bool> DeleteGuestAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id); // Find the guest by ID.
            if (guest == null) return false; // Return false if guest is not found.

            // Remove the guest from the context and save changes to the database.
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return true; // Return true indicating successful deletion.
        }
    }
}
