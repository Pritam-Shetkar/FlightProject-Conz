using LoginAPIService.Models;
using LoginAPIService.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPIService.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        FlightProjectDBContext db;
        public InventoryController(FlightProjectDBContext _db)
        {
            db = _db;
        }
       
        [HttpGet]
      
       [Route("GetAllFLight")]
        public IEnumerable<Inventory> getData()
        {
            return db.Inventories.ToList();
        }
        [HttpPost]
        [Route("ScheduledFlight")]
        public IActionResult postinventory([FromBody] InventoryViewMode inventoryViewMode)
        {
            Inventory it = new Inventory();
            it.FlightNumber = inventoryViewMode.FlightNumber;

            it.FromPlace = inventoryViewMode.FromPlace;
            it.ToPlace = inventoryViewMode.ToPlace;
            it.StartDateTime = inventoryViewMode.StartDateTime;
            it.EndDateTime = inventoryViewMode.EndDateTime;
            it.ScheduleDay = inventoryViewMode.ScheduleDay;
            it.InstrumentUsed = inventoryViewMode.InstrumentUsed;
            it.TbussinessClassSeat = inventoryViewMode.TbussinessClassSeat;
            it.TnobussinessClassSeat = inventoryViewMode.TnobussinessClassSeat;
            it.TicketCost = inventoryViewMode.TicketCost;
            it.NumberOfRows = inventoryViewMode.NumberOfRows;
            it.Meal = inventoryViewMode.Meal;
            db.Inventories.Add(it);
            db.SaveChanges();
            return Ok("inventory data added successfully");
        }
    }
}
