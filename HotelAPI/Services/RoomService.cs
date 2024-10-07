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
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomDTO>> GetAvailableRoomsAsync()
        {
            return await _context.Rooms
                .Where(r => r.Availability)
                .Select(r => new RoomDTO
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    PricePerNight = r.PricePerNight,
                    Availability = r.Availability
                }).ToListAsync();
        }

        public async Task<(int availableRooms, List<Room> availableRoomList, int occupiedRooms, List<Room> occupiedRoomList)> GetRoomStatusAsync()
        {
            var availableRoomList = await _context.Rooms.Where(r => r.Availability).ToListAsync();
            var occupiedRoomList = await _context.Rooms.Where(r => !r.Availability).ToListAsync();

            var availableRooms = availableRoomList.Count;
            var occupiedRooms = occupiedRoomList.Count;

            return (availableRooms, availableRoomList, occupiedRooms, occupiedRoomList);
        }

    }
}