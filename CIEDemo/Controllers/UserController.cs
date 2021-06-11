using CIEDemo.Models;
using CIEDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIEDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;

        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> UserList()
        {
            return await _repository.SelectAll<User>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var model = await _repository.SelectByID<User>(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, User model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<User>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> InsertUser([FromBody] User model)
        {
            await _repository.CreateAsync<User>(model);
            return CreatedAtAction("GetUser", new { id = model.ID }, model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var model = await _repository.SelectByID<User>(id);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<User>(model);

            return model;
        }
    }
}
