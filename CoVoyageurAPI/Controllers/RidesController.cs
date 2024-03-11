using CoVoyageurCore.Models;
using CoVoyageurAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoVoyageurAPI.Controllers
{
    [Route("api/rides")]
    [ApiController]
    //[Authorize(Policy = Constants.PolicyAdmin)]
    public class RidesController : ControllerBase
    {
        private readonly IRepository<Ride> _rideRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Rating> _ratingRepository;


        public RidesController(IRepository<Ride> rideRepository,
                                IRepository<User> userRepository,
                                IRepository<Rating> ratingRepository)
        {
            _rideRepository = rideRepository;
            _userRepository = userRepository;
            _ratingRepository = ratingRepository;
        }

        [HttpGet]
        //[Authorize(Roles = Constants.RoleUser+","+Constants.RoleAdmin)]
        public async Task<IActionResult> Menu()
        {
            return Ok(await _rideRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _rideRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddRide([FromBody] Ride ride)
        {
            var rideId = await _rideRepository.Add(ride);

            if (rideId > 1)
                return CreatedAtAction(nameof(Menu), "Ride added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRide(int id, [FromBody] Ride ride)
        {
            var rid = await _rideRepository.GetById(id);
            if (rid == null)
                return BadRequest("Ride not found");

            ride.Id = id;
            if (await _rideRepository.Update(ride))
                return Ok("Ride Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRide(int id)
        {
            var rid = await _rideRepository.GetById(id);
            if (rid == null)
                return BadRequest("Ride not found");

            if (await _rideRepository.Delete(id))
                return Ok("Ride Updated !");

            return BadRequest("Something went wrong...");
        }
    }
}
