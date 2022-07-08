using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAPIServices.Models
{
    public partial class AirlineList
    {
        public AirlineList()
        {
            BookingFlights = new HashSet<BookingFlight>();
        }

        public int AirlineId { get; set; }
        public string AirlinesNames { get; set; }
        public string LogoPath { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }

        public virtual ICollection<BookingFlight> BookingFlights { get; set; }
    }
}
