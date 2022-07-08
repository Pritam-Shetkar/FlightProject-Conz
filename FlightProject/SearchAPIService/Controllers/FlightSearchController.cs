using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightSearchController : ControllerBase
    {
        FlightProjectDBContext db;
        public FlightSearchController(FlightProjectDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("SearchFlight")]
        public IEnumerable<Inventory> Search(string fromplace, string toplace,DateTime date1)
        {
            
            var data = db.Inventories;
            List<Inventory> list = new List<Inventory>();
            foreach (var item in data)
            {
                if((item.FromPlace==fromplace && item.ToPlace==toplace)||item.StartDateTime==date1)
                {
                    list.Add(item);
                }
               
            }
            return list;
        }

    }
}
