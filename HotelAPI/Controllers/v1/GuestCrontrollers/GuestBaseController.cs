using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.v1.GuestCrontrollers
{
    public class GuestBaseController : ControllerBase
    {
        protected readonly IGuestService _guestService;

        public GuestBaseController(IGuestService guestService)
        {
            _guestService = guestService;
        }
    }
}