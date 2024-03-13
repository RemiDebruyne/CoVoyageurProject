using CoVoyageurAPI.Helpers;
using CoVoyageurAPI.Repositories;
using CoVoyageurCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CoVoyageurAPI.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    [Authorize]
    public class ProfilesController : ControllerBase
    {
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Car> _carRepository;


        public ProfilesController(IRepository<Profile> profileRepository,
                                IRepository<User> userRepository,
                                IRepository<Car> carRepository)
        {
            _profileRepository = profileRepository;
            _userRepository = userRepository;
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            return Ok(await _profileRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _profileRepository.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> AddProfile([FromBody] Profile profile)
        {
            var profileId = await _profileRepository.Add(profile);

            if (profileId > 1)
                return CreatedAtAction(nameof(Menu), "Profile added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] Profile profile)
        {
            var profil = await _profileRepository.GetById(id);
            if (profil == null)
                return BadRequest("Profile not found");

            profile.Id = id;
            if (await _profileRepository.Update(profile))
                return Ok("Profile Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> RemoveProfile(int id)
        {
            var profil = await _profileRepository.GetById(id);
            if (profil == null)
                return BadRequest("Profile not found");

            if (await _profileRepository.Delete(id))
                return Ok("Profile Deleted !");

            return BadRequest("Something went wrong...");
        }
    }
}
