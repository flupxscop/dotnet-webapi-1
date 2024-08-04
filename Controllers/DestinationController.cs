using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Data;
using dotnet_webapi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public DestinationController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var destinations = _context.Destinations.Select(c => c.ToDestinationDTO());
            return Ok(destinations);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var destination = _context.Destinations.Where(d => d.Idx == id).Select(c => c.ToDestinationDTO()).FirstOrDefault();
            if(destination == null){
                return NotFound();
            }
            return Ok(destination);
        }
    }
}