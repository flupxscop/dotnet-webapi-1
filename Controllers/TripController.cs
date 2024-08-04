using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Data;
using dotnet_webapi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private  readonly ApplicationDBContext _context;
        //ctor
        public TripController(ApplicationDBContext context){
            _context=context;
        }
        //http/localhost:8000/api/trip
        [HttpGet]
        public IActionResult GetAll(){
            var trip =_context.Trips.Include(t => t.Destination).Select(t => t.ToTripDTOs());
            System.Console.WriteLine(trip.Count());
            return Ok(trip);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID([FromRoute] int id){
            var trip=_context.Trips.Include(t=>t.Destination).Where(t=>t.Idx==id).FirstOrDefault();
            if(trip==null){
                return NotFound();
            }
            return Ok(trip.ToTripDTOs());
        }
    }

    
}