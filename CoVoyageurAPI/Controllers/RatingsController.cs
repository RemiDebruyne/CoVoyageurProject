using CoVoyageurCore.Models;
using CoVoyageurAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoVoyageurAPI.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    //[Authorize(Policy = Constants.PolicyAdmin)]
    public class RatingsController : ControllerBase
    {
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Ride> _rideRepository;

        public RatingsController(IRepository<Rating> ratingRepository,
                                IRepository<User> userRepository,
                                IRepository<Ride> rideRepository)
        {
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
            _rideRepository = rideRepository;
        }

        [HttpGet]
        //[Authorize(Roles = Constants.RoleUser+","+Constants.RoleAdmin)]
        public async Task<IActionResult> Menu()
        {
            return Ok(await _ratingRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _ratingRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddRating([FromBody] Rating rating)
        {
            var ratingId = await _ratingRepository.Add(rating);

            if (ratingId > 1)
                return CreatedAtAction(nameof(Menu), "Rating added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] Rating rating)
        {
            var ratin = await _ratingRepository.GetById(id);
            if (ratin == null)
                return BadRequest("Rating not found");

            rating.Id = id;
            if (await _ratingRepository.Update(rating))
                return Ok("Rating Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRating(int id)
        {
            var ratin = await _ratingRepository.GetById(id);
            if (ratin == null)
                return BadRequest("Rating not found");

            if (await _ratingRepository.Delete(id))
                return Ok("Rating Updated !");

            return BadRequest("Something went wrong...");
        }
    }
}
