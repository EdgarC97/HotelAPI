using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.v1.BookingControllers
{
    public class BookingBaseController : ControllerBase
    {
        protected readonly IBookingService _bookingService;

        public BookingBaseController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
    }
}