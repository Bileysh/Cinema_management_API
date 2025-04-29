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
    public class DiscountController : ControllerBase
    {
        private Cinema_management context;
        private readonly IMapper mapper;
        public DiscountController(IMapper mapper, Cinema_management context)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Discounts.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = context.Discounts.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(CreateDiscountModel discount)
        {
            context.Discounts.Add(mapper.Map<Discount>(discount));
            context.SaveChanges();
            return Created();
        }
        [HttpPut]
        public IActionResult Edit(EditDiscountModel discount)
        {
            context.Discounts.Update(mapper.Map<Discount>(discount));
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = context.Discounts.Find(id);
            if (item == null) return NotFound();
            context.Discounts.Remove(item);
            context.SaveChanges();
            return NoContent();
        }
    }

}
