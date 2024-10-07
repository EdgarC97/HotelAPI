using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.v1.RoomsControllers
{
    public class RoomBaseController : ControllerBase
    {
        protected readonly IRoomService _roomService;

        public RoomBaseController(IRoomService roomService)
        {
            _roomService = roomService;
        }

    }
}