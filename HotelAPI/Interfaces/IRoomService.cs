using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.DTOS;
using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetAvailableRoomsAsync();
        Task<(int availableRooms, List<Room> availableRoomList, int occupiedRooms, List<Room> occupiedRoomList)> GetRoomStatusAsync();
    }

}

