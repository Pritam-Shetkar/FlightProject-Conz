using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPIService.ViewModel
{
    public class BookingViewModel
    {
        public int BookFlightId { get; set; }
        public int? AirlineId { get; set; }
        public string PassName { get; set; }
        public string PassGender { get; set; }
        public string SeatNumber { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Meal { get; set; }
        public string Pnr { get; set; }
    }
}
