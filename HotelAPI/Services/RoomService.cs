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
    // Service class that implements room-related operations.
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context; // Database context for accessing room data.

        // Constructor that initializes the RoomService with the required dependencies.
        public RoomService(AppDbContext context)
        {
            _context = context; // Assign the database context.
        }

        // Asynchronously retrieves all available rooms and maps them to RoomDTO objects.
        public async Task<IEnumerable<RoomDTO>> GetAvailableRoomsAsync()
        {
            return await _context.Rooms
                .Where(r => r.Availability) // Filter for available rooms.
                .Select(r => new RoomDTO
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    PricePerNight = r.PricePerNight,
                    Availability = r.Availability
                }).ToListAsync(); // Convert to a list asynchronously.
        }

        // Asynchronously retrieves the status of rooms, including counts and lists of available and occupied rooms.
        public async Task<(int availableRooms, List<Room> availableRoomList, int occupiedRooms, List<Room> occupiedRoomList)> GetRoomStatusAsync()
        {
            var availableRoomList = await _context.Rooms.Where(r => r.Availability).ToListAsync(); // Get available rooms.
            var occupiedRoomList = await _context.Rooms.Where(r => !r.Availability).ToListAsync(); // Get occupied rooms.

            var availableRooms = availableRoomList.Count; // Count available rooms.
            var occupiedRooms = occupiedRoomList.Count; // Count occupied rooms.

            return (availableRooms, availableRoomList, occupiedRooms, occupiedRoomList); // Return counts and lists.
        }

        // Asynchronously retrieves all room types and maps them to RoomTypeDTO objects.
        public async Task<IEnumerable<RoomTypeDTO>> GetAllRoomTypesAsync()
        {
            return await _context.RoomTypes
                .Select(rt => new RoomTypeDTO
                {
                    Id = rt.Id,
                    Name = rt.Name,
                    Description = rt.Description
                }).ToListAsync(); // Convert to a list asynchronously.
        }

        // Asynchronously retrieves a room type by its ID and maps the data to a RoomTypeDTO object.
        public async Task<RoomTypeDTO> GetRoomTypeByIdAsync(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id); // Find the room type by ID.
            if (roomType == null) return null; // Return null if no room type is found.

            // Map the RoomType entity to RoomTypeDTO for the response.
            return new RoomTypeDTO
            {
                Id = roomType.Id,
                Name = roomType.Name,
                Description = roomType.Description
            };
        }

        // Asynchronously retrieves all rooms and maps them to RoomDTO objects.
        public async Task<IEnumerable<RoomDTO>> GetAllRoomsAsync()
        {
            return await _context.Rooms
                .Select(r => new RoomDTO
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    PricePerNight = r.PricePerNight,
                    Availability = r.Availability
                }).ToListAsync(); // Convert to a list asynchronously.
        }

        // Asynchronously retrieves a room by its ID and maps the data to a RoomDTO object.
        public async Task<RoomDTO> GetRoomByIdAsync(int id)
        {
            var room = await _context.Rooms
                .Where(r => r.Id == id) // Find the room by ID.
                .Select(r => new RoomDTO
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    PricePerNight = r.PricePerNight,
                    Availability = r.Availability
                })
                .FirstOrDefaultAsync(); // Return the first matching room or null.

            return room; // Return the room DTO.
        }

        // Asynchronously retrieves all occupied rooms and maps them to RoomDTO objects.
        public async Task<IEnumerable<RoomDTO>> GetOccupiedRoomsAsync()
        {
            return await _context.Rooms
                .Where(r => !r.Availability) // Filter for occupied rooms.
                .Select(r => new RoomDTO
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    PricePerNight = r.PricePerNight,
                    Availability = r.Availability
                }).ToListAsync(); // Convert to a list asynchronously.
        }
    }
}
