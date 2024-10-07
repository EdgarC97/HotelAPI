using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.v1.RoomsControllers
{
    /// <summary>
    /// API controller for managing room-related actions, including retrieval of rooms and room types.
    /// </summary>
    [ApiController]
    [Route("api/v1/rooms")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GetRoomController : RoomBaseController
    {
        public GetRoomController(IRoomService roomService) : base(roomService) { }

        /// <summary>
        /// Retrieves a list of all available rooms.
        /// </summary>
        /// <returns>An IActionResult containing the list of available rooms.</returns>
        /// <response code="200">Returns a list of available rooms.</response>
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var rooms = await _roomService.GetAvailableRoomsAsync();
            return Ok(new
            {
                message = "Available Rooms",
                data = rooms
            });
        }

        /// <summary>
        /// Retrieves a list of all room types.
        /// </summary>
        /// <returns>An IActionResult containing the list of room types.</returns>
        /// <response code="200">Returns a list of room types.</response>
        [HttpGet("room_types")]
        public async Task<IActionResult> GetRoomTypes()
        {
            var roomTypes = await _roomService.GetAllRoomTypesAsync();
            return Ok(new
            {
                message = "Room Types",
                data = roomTypes
            });
        }

        /// <summary>
        /// Retrieves details of a specific room type by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the room type to retrieve.</param>
        /// <returns>An IActionResult containing the room type details.</returns>
        /// <response code="200">Returns the details of the specified room type.</response>
        /// <response code="404">Returns an error message if the room type is not found.</response>
        [HttpGet("room_types/{id}")]
        public async Task<IActionResult> GetRoomType(int id)
        {
            var roomType = await _roomService.GetRoomTypeByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Room Type Details",
                data = roomType
            });
        }

        /// <summary>
        /// Retrieves the status of all rooms, including available and occupied rooms.
        /// </summary>
        /// <returns>An IActionResult containing the status of all rooms.</returns>
        /// <response code="200">Returns the status of all rooms.</response>
        [HttpGet("status")]
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

        /// <summary>
        /// Retrieves a list of all rooms.
        /// </summary>
        /// <returns>An IActionResult containing the list of all rooms.</returns>
        /// <response code="200">Returns a list of all rooms.</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(new
            {
                message = "All Rooms",
                data = rooms
            });
        }

        /// <summary>
        /// Retrieves details of a specific room by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the room to retrieve.</param>
        /// <returns>An IActionResult containing the room details.</returns>
        /// <response code="200">Returns the details of the specified room.</response>
        /// <response code="404">Returns an error message if the room is not found.</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound(new { message = "Room not found" });
            }
            return Ok(new
            {
                message = "Room details",
                data = room
            });
        }

        /// <summary>
        /// Retrieves a list of all occupied rooms.
        /// </summary>
        /// <returns>An IActionResult containing the list of occupied rooms.</returns>
        /// <response code="200">Returns a list of occupied rooms.</response>
        [HttpGet("occupied")]
        [Authorize]
        public async Task<IActionResult> GetOccupiedRooms()
        {
            var occupiedRooms = await _roomService.GetOccupiedRoomsAsync();
            return Ok(new
            {
                message = "Occupied Rooms",
                data = occupiedRooms
            });
        }
    }
}