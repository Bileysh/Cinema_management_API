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
    public class SalesController : ControllerBase
    {
        private Cinema_management context;
        private readonly IMapper mapper;
        public SalesController(IMapper mapper, Cinema_management context)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var sales = context.Sales
                .Include(s => s.User)
                    .ThenInclude(u => u.Tickets)
                        .ThenInclude(t => t.Session)
                .ToList();
            if (sales == null) return NotFound();
            var response = mapper.Map<List<ResponseSalesModel>>(sales);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sales = context.Sales
                .Include(s => s.User)
                    .ThenInclude(u => u.Tickets)
                        .ThenInclude(t => t.Session)
                .FirstOrDefault(s => s.Id == id);
            if (sales == null) return NotFound();
            var response = mapper.Map<ResponseSalesModel>(sales);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Create(CreateSalesModel sales)
        {
            var user = context.Users.Find(sales.UserId);
            if (user == null) return NotFound();
            var sale = mapper.Map<Sales>(sales);
            sale.User = user;
            context.Sales.Add(sale);
            context.SaveChanges();
            var response = mapper.Map<ResponseSalesModel>(sale);
            return CreatedAtAction(nameof(Get), new { id = sale.Id }, response);
        }
        [HttpPut]
        public IActionResult Edit(EditSalesModel sales)
        {
            var user = context.Users.Find(sales.UserId);
            if (user == null) return NotFound();
            var sale = mapper.Map<Sales>(sales);
            sale.User = user;
            context.Sales.Update(sale);
            context.SaveChanges();
            var response = mapper.Map<ResponseSalesModel>(sale);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sales = context.Sales.Find(id);
            if (sales == null) return NotFound();
            context.Sales.Remove(sales);
            context.SaveChanges();
            return NoContent();
        }
    }
}
