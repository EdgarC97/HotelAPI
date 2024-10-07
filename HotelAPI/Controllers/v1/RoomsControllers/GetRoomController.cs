using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.v1.RoomsControllers
{
    [ApiController]
    [Route("api/v1/rooms")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GetRoomController : RoomBaseController
    {
        public GetRoomController(IRoomService roomService) : base(roomService)
        {
        }

        // GET: api/v1/rooms/available
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var rooms = await _roomService.GetAvailableRoomsAsync();
            return Ok(new
            {
                message = "Avaliable Rooms",
                data = rooms
            });
        }

        // GET: api/v1/rooms/status
        [HttpGet]
        public async Task<IActionResult> GetRoomStatus()
        {
            var (availableRooms, availableRoomList, occupiedRooms, occupiedRoomList) = await _roomService.GetRoomStatusAsync();

            return Ok(new
            {
                AvailableRooms = availableRooms,
                AvailableRoomList = availableRoomList,
                OccupiedRooms = occupiedRooms,
                OccupiedRoomList = occupiedRoomList
            });
        }
    }
}
