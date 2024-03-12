using CoVoyageurCore.Models;
using CoVoyageurAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoVoyageurAPI.Helpers;

namespace CoVoyageurAPI.Controllers
{
    [Route("api/cars")]
    [ApiController]
    [Authorize]
    public class CarsController : ControllerBase
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<User> _userRepository;

        public CarsController(IRepository<Car> carRepository,
                                IRepository<User> userRepository)
        {
            _carRepository = carRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Menu()
        {
            return Ok(await _carRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _carRepository.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            var carId = await _carRepository.Add(car);

            if (carId > 1)
                return CreatedAtAction(nameof(Menu), "Car added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {
            var ca = await _carRepository.GetById(id);
            if (ca == null)
                return BadRequest("Car not found");

            car.Id = id;
            if (await _carRepository.Update(car))
                return Ok("Car Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var ca = await _carRepository.GetById(id);
            if (ca == null)
                return BadRequest("Car not found");

            if (await _carRepository.Delete(id))
                return Ok("Car Updated !");

            return BadRequest("Something went wrong...");
        }
    }
}
