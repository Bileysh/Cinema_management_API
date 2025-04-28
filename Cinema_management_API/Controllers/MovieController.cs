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
    public class MovieController : ControllerBase
    {
        private Cinema_management context;
        private readonly IMapper mapper;
        public MovieController(IMapper mapper, Cinema_management context)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Movies.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = context.Movies.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(CreateMovieModel movie)
        {
            context.Movies.Add(mapper.Map<Movie>(movie));
            context.SaveChanges();
            return Created();
        }
        [HttpPut]
        public IActionResult Edit(EditMovieModel movie)
        {
            context.Movies.Update(mapper.Map<Movie>(movie));
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = context.Movies.Find(id);
            if (item == null) return NotFound();
            context.Movies.Remove(item);
            context.SaveChanges();
            return NoContent();
        }
    }
}
