using Microsoft.AspNetCore.Mvc;
using CoVoyageurCore.Models;
using CoVoyageurAPI.Repositories;

namespace CoVoyageurCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly RatingRepository _repository;

        public RatingsController(RatingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> Get()
        {
            var ratings = await _repository.GetAll();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> Get(int id)
        {
            var rating = await _repository.GetById(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> Post(Rating rating)
        {
            await _repository.Add(rating);
            return CreatedAtAction(nameof(Get), new { id = rating.Id }, rating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Rating rating)
        {
            if (id != rating.Id)
            {
                return BadRequest();
            }
            var result = await _repository.Update(rating);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
