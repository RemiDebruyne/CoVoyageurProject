using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoVoyageurCore.Models;
using CoVoyageurAPI.Repositories;

namespace CoVoyageurCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly RideRepository _repository;

        public RidesController(RideRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ride>>> Get()
        {
            var rides = await _repository.GetAll();
            return Ok(rides);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ride>> Get(int id)
        {
            var ride = await _repository.GetById(id);
            if (ride == null)
            {
                return NotFound();
            }
            return Ok(ride);
        }

        [HttpPost]
        public async Task<ActionResult<Ride>> Post(Ride ride)
        {
            await _repository.Add(ride);
            return CreatedAtAction(nameof(Get), new { id = ride.Id }, ride);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Ride ride)
        {
            if (id != ride.Id)
            {
                return BadRequest();
            }
            var result = await _repository.Update(ride);
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
