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
    public class UserController : ControllerBase
    {
        private Cinema_management context;
        private readonly IMapper mapper;

        public UserController(IMapper mapper, Cinema_management context) 
        { 
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = context.Users
                .Include(u => u.Discount)
                .ToList();
            var response = mapper.Map<List<ResponseUserModel>>(users);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = context.Users
                .Include(u => u.Discount)
                .FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            var response = mapper.Map<ResponseUserModel>(user);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Create(CreateUserModel users)
        {
            var discount = context.Discounts.Find(users.DiscountId);
            var user = mapper.Map<User>(users);

            user.Discount = discount;

            context.Users.Add(mapper.Map<User>(user));
            context.SaveChanges();

            var response = mapper.Map<ResponseUserModel>(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, response);
        }
        [HttpPut]
        public IActionResult Edit(EditUserModel users)
        {

            var discount = context.Discounts.Find(users.DiscountId);

            var user = mapper.Map<User>(users);

            user.Discount = discount;

            context.Users.Update(mapper.Map<User>(user));
            context.SaveChanges();

            var response = mapper.Map<ResponseUserModel>(user);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = context.Users.Find(id);
            if (item == null) return NotFound();
            context.Users.Remove(item);
            context.SaveChanges();
            return NoContent();
        }

    }
}
