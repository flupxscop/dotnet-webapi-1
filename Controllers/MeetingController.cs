using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Data;
using dotnet_webapi.DTOs.Trips;
using dotnet_webapi.Mappers;
using dotnet_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MeetingController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var meetings = _context.Meetings;//.Select(m => m.ToMeetingDTO());
            return Ok(meetings);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var meeting = _context.Meetings.Where(m => m.Idx == id).Select(m => m.ToMeetingDTO()).FirstOrDefault();
            if (meeting == null)
            {
                return NotFound();
            }
            return Ok(meeting);
        }
        [HttpPost]
        public IActionResult InsertMeeting([FromBody] MeetingDTO meetingDTO)
        {
            var meeting = meetingDTO.ToMeeting();
            _context.Meetings.Add(meeting);
            int affect = _context.SaveChanges();
            if (affect > 0)
            {
                //create ORM 
                return CreatedAtAction(nameof(GetById), new { id = meeting.Idx }, meeting.ToMeetingDTO());
            }
            return StatusCode(400);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMeeting([FromRoute] int id)
        {
            Meeting meeting = _context.Meetings.Find(id);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
                int affect = _context.SaveChanges();
                if (affect > 0)
                {
                    return Ok(affect + " affected row");
                }
            }
            return StatusCode(404);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMeeting([FromRoute] int id, [FromBody] MeetingDTO2 meetingDTO2)
        {
            Meeting meeting = _context.Meetings.Find(id);
            if (meeting != null)
            {
                meeting.Detail = meetingDTO2.Detail;
                meeting.Meetingdatetime = meetingDTO2.Meetingdatetime;
                meeting.Latitude = meetingDTO2.Latitude;
                meeting.Longitude = meetingDTO2.Longitude;
                _context.Meetings.Update(meeting);
                int affect = _context.SaveChanges();
                if (affect > 0)
                {
                    return Accepted(meeting.ToMeetingDTO());
                }
            }
            return StatusCode(404);

        }

    }
}