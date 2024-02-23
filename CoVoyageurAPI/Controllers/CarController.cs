using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoVoyageurCore.Models;
using CoVoyageurAPI.Repositories;

namespace CoVoyageurCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarRepository _repository;

        public CarsController(CarRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            var cars = await _repository.GetAll();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _repository.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            await _repository.Add(car);
            return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }
            var result = await _repository.Update(car);
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
