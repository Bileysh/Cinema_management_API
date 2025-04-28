using AutoMapper;
using Cinema_management_API.Models;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private Cinema_management context;
        private readonly IMapper mapper;
        public HallController(IMapper mapper, Cinema_management context)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Halls.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = context.Halls.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(CreateHallModel hall) { 
            context.Halls.Add(mapper.Map<Hall>(hall));
            context.SaveChanges();
            return Created();
        }
        [HttpPut]
        public IActionResult Edit(CreateHallModel hall)
        {
            context.Halls.Update(mapper.Map<Hall>(hall));
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = context.Halls.Find(id);
            if (item == null) return NotFound();
            context.Halls.Remove(item);
            context.SaveChanges();
            return NoContent();
        }

    }
}
