using BookingAPIService.Models;
using BookingAPIService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookFlightController : ControllerBase
    {
        FlightProjectDBContext db;

        #region oldCode

        public BookFlightController(FlightProjectDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("FLightBooked")]
        public IEnumerable<BookingFlight> GetData()
        {
            return db.BookingFlights;
        }
        [HttpPost]
        [Route("registerBooking")]
        public IActionResult registerBooking([FromBody] BookingViewModel bookingViewModel)
        {
            Random random = new Random();
            int pnr = random.Next();
            BookingFlight bfs = new BookingFlight();
            bfs.BookFlightId = bookingViewModel.BookFlightId;
            bfs.AirlineId = bookingViewModel.AirlineId;
            bfs.Age = bookingViewModel.Age;
            bfs.PassName = bookingViewModel.PassName;
            bfs.PassGender = bookingViewModel.PassGender;
            bfs.SeatNumber = bookingViewModel.SeatNumber;
            bfs.Address = bookingViewModel.Address;
            bfs.Contact = bookingViewModel.Contact;
            bfs.Email = bookingViewModel.Email;
            bfs.Meal = bookingViewModel.Meal;

            bfs.Pnr = pnr.ToString();

            db.BookingFlights.Add(bfs);
            db.SaveChanges();
            return Ok("Booking successfully ");
        }
        [HttpGet]
        [Route("ticket/pnr")]
        public IActionResult GetTicketsPNR(string pnr)
        {
            var data = db.BookingFlights.FirstOrDefault(x => x.Pnr == pnr);
            if (data == null)
            {
                return BadRequest("Record not found.");


            }
            return Ok(data);

        }
        [HttpGet]
        [Route("history/email")]
        public IActionResult GetTickets(string email)
        {
            var data = db.BookingFlights.FirstOrDefault(x => x.Email == email);
            if (data == null)
            {
                return BadRequest("Record not found.");


            }
            return Ok(data);

        }
        [HttpDelete]
        [Route("cancelTicket/pnr")]
        public IActionResult CancelTicekt(string pnr)
        {
            if (db.BookingFlights.Any(x => x.Pnr == pnr))
            {
                var data = db.BookingFlights.Where(x => x.Pnr == pnr).FirstOrDefault();
                db.BookingFlights.Remove(data);
                db.SaveChanges();
                return Ok("Ticket have been successfully canceled.");
            }
            return BadRequest("Record not found.");
        }

        #endregion oldCode

    }
}
