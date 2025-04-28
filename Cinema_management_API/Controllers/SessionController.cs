using AutoMapper;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(context.Sessions.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = context.Sessions.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(Session sessions)
        {
            context.Sessions.Add(sessions);
            context.SaveChanges();
            return Created();
        }
        [HttpPut]
        public IActionResult Edit(Session sessions)
        {
            context.Sessions.Update(sessions);
            context.SaveChanges();
            return Ok();
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
