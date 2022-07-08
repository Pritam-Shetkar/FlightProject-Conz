using BookingAPIService.Models;
using BookingAPIService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPIService.Services
{
   public interface IBookingFlightServices
    {
        IEnumerable<BookingFlight> GetData();
        IActionResult registerBooking([FromBody] BookingViewModel bookingViewModel);
        IActionResult GetTicketsPNR(string pnr);
        IActionResult GetTickets(string email);
        IActionResult CancelTicekt(string pnr);
    }
}
