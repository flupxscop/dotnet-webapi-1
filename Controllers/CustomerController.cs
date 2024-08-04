using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CustomerController(ApplicationDBContext context)
        {
            _context = context ;
        }
        [HttpGet]
        public IActionResult GetAll(){
            var customer= _context.Customers.ToList();
            return Ok(customer);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID([FromRoute] int id){
            var customer=_context.Customers.Find(id);
            if(customer==null){
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpGet("name/{name}")]
        public IActionResult GetByName([FromRoute] string name){
            var customer=_context.Customers.Where(c=>c.Fullname.Contains(name));
            return Ok(customer);
        }
    }
}