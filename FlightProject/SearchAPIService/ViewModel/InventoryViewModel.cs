using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchAPIService.ViewModel
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string ScheduleDay { get; set; }
        public string InstrumentUsed { get; set; }
        public int? TbussinessClassSeat { get; set; }
        public int? TnobussinessClassSeat { get; set; }
        public long? TicketCost { get; set; }
        public int? NumberOfRows { get; set; }
        public string Meal { get; set; }
    }
}
