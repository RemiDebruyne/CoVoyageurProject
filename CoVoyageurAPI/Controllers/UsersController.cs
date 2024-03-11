using CoVoyageurCore.Models;
using CoVoyageurAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoVoyageurAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    //[Authorize(Policy = Constants.PolicyAdmin)]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IRepository<Profile> _profileRepository;


        public UsersController(IRepository<User> userRepository,
                                IRepository<Rating> ratingRepository,
                                IRepository<Profile> profileRepository)
        {
            _userRepository = userRepository;
            _ratingRepository = ratingRepository;
            _profileRepository = profileRepository;
        }

        [HttpGet]
        //[Authorize(Roles = Constants.RoleUser+","+Constants.RoleAdmin)]
        public async Task<IActionResult> Menu()
        {
            return Ok(await _userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var userId = await _userRepository.Add(user);

            if (userId > 1)
                return CreatedAtAction(nameof(Menu), "User added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var use = await _userRepository.GetById(id);
            if (use == null)
                return BadRequest("User not found");

            user.Id = id;
            if (await _userRepository.Update(user))
                return Ok("User Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var use = await _userRepository.GetById(id);
            if (use == null)
                return BadRequest("User not found");

            if (await _userRepository.Delete(id))
                return Ok("User Updated !");

            return BadRequest("Something went wrong...");
        }
    }
}
