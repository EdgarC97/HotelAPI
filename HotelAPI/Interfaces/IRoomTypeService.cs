using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.DTOS;

namespace HotelAPI.Interfaces
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeDTO>> GetAllRoomTypesAsync();
        Task<RoomTypeDTO> GetRoomTypeByIdAsync(int id);
    }
}