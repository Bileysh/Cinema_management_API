using AutoMapper;
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
    public class SessionController : ControllerBase
    {
        private Cinema_management context;
        private readonly IMapper mapper;
        public SessionController(IMapper mapper, Cinema_management context)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var sessions = context.Sessions
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .ToList();
            var response = mapper.Map<List<ResponseSessionModel>>(sessions);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sessions = context.Sessions
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .FirstOrDefault(s => s.Id == id);
            if (sessions == null) return NotFound();
            var response = mapper.Map<ResponseSessionModel>(sessions);

            return Ok(response);
        }
        [HttpPost]
        public IActionResult Create(CreateSessionModel sessions)
        {
            var movie = context.Movies.Find(sessions.MovieId);
            var hall = context.Halls.Find(sessions.HallId);
            if(movie == null || hall == null) return NotFound();

            var session = mapper.Map<Session>(sessions);

            session.Movie = movie;
            session.Hall = hall;

            context.Sessions.Add(session);
            
            context.SaveChanges();

             var response = mapper.Map<ResponseSessionModel>(session);

            return CreatedAtAction(nameof(Get), new { id = session.Id }, response);
        }
        [HttpPut]
        public IActionResult Edit(EditSessionModel sessions)
        {
            var movie = context.Movies.Find(sessions.MovieId);
            var hall = context.Halls.Find(sessions.HallId);
            if (movie == null || hall == null) return NotFound();

            var session = mapper.Map<Session>(sessions);

            session.Movie = movie;
            session.Hall = hall;

            context.Sessions.Update(session);
            context.SaveChanges();

            var response = mapper.Map<ResponseSessionModel>(session);


            return Ok(response);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = context.Sessions.Find(id);
            if (item == null) return NotFound();
            context.Sessions.Remove(item);
            context.SaveChanges();
            return NoContent();
        }
    }
}
