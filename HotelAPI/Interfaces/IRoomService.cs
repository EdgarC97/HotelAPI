using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.DTOS;
using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    // Interface for the room service that defines methods for managing room-related operations.
    public interface IRoomService
    {
        // Asynchronously retrieves a list of available rooms and returns them as RoomDTO objects.
        Task<IEnumerable<RoomDTO>> GetAvailableRoomsAsync();

        // Asynchronously retrieves the status of rooms, including counts and lists of available and occupied rooms.
        // Returns a tuple containing the count of available rooms, a list of available rooms,
        // the count of occupied rooms, and a list of occupied rooms.
        Task<(int availableRooms, List<Room> availableRoomList, int occupiedRooms, List<Room> occupiedRoomList)> GetRoomStatusAsync();

        // Asynchronously retrieves all room types and returns them as RoomTypeDTO objects.
        Task<IEnumerable<RoomTypeDTO>> GetAllRoomTypesAsync();

        // Asynchronously retrieves a room type by its ID and returns the corresponding RoomTypeDTO.
        Task<RoomTypeDTO> GetRoomTypeByIdAsync(int id);

        // Asynchronously retrieves a list of all rooms and returns them as RoomDTO objects.
        Task<IEnumerable<RoomDTO>> GetAllRoomsAsync();

        // Asynchronously retrieves a room by its ID and returns the corresponding RoomDTO.
        Task<RoomDTO> GetRoomByIdAsync(int id);

        // Asynchronously retrieves a list of occupied rooms and returns them as RoomDTO objects.
        Task<IEnumerable<RoomDTO>> GetOccupiedRoomsAsync();
    }
}


