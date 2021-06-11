using CIEDemo.Models;
using CIEDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CIEDemo.Controllers
{
    [Route("api/Movie")]
    [Authorize]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IRepository _repository;

        public MovieController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> MovieList()
        {
            return await _repository.SelectAll<Movie>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(long id)
        {
            var model = await _repository.SelectByID<Movie>(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(long id, Movie model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<Movie>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> InsertMovie([FromBody]Movie model)
        {
            await _repository.CreateAsync<Movie>(model);
            return CreatedAtAction("GetMovie", new { id = model.ID }, model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(long id)
        {
            var model = await _repository.SelectByID<Movie>(id);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Movie>(model);

            return model;
        }
    }
}
