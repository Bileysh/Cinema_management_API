using AutoMapper;
using Azure;
using Cinema_management_API.Models;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private Cinema_management context;
        private readonly IMapper mapper;

        public TicketController(IMapper mapper, Cinema_management context)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var tickets = context.Tickets
                .Include(t => t.Session)
                .Include(t => t.Session.Movie)
                .Include(t => t.Session.Hall)
                .Include(t => t.User)
                .ToList();
            var response = mapper.Map<List<ResponseTicketModel>>(tickets);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tickets = context.Tickets
                .Include(t => t.Session)
                .Include(t => t.Session.Movie)
                .Include(t => t.Session.Hall)
                .Include(t => t.User)
                .FirstOrDefault(t => t.Id == id);
            if (tickets == null) return NotFound();
            return Ok(tickets);
        }
        [HttpPost]
        public IActionResult Create(CreateTicketModel tickets)
        {
            var session = context.Sessions.Find(tickets.SessionId);
            if (session == null) return NotFound();

            var ticket = mapper.Map<Ticket>(tickets);

            ticket.Session = session;

            context.Tickets.Add(ticket);
            context.SaveChanges();

            var response = mapper.Map<ResponseTicketModel>(ticket);

            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, response);
        }
        [HttpPut]
        public IActionResult Edit(EditTicketModel tickets)
        {
            var session = context.Sessions.Find(tickets.SessionId);
            if (session == null) return NotFound();
            var ticket = mapper.Map<Ticket>(tickets);
            ticket.Session = session;
            context.Tickets.Update(ticket);
            context.SaveChanges();
            var response = mapper.Map<ResponseTicketModel>(ticket);
            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, response);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = context.Tickets.Find(id);
            if (item == null) return NotFound();
            context.Tickets.Remove(item);
            context.SaveChanges();
            return NoContent();
        }
    }
}
