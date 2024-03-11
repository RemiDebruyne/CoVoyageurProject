using CoVoyageurAPI.Datas;
using CoVoyageurAPI.Helpers;
using CoVoyageurAPI.Repositories;
using CoVoyageurCore.Controllers;
using CoVoyageurCore.DTOs;
using CoVoyageurCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization.Metadata;

namespace CoVoyageurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly AppSettings _appSettings;

        public AuthenticationController(IRepository<User> repository, IOptions<AppSettings> appSettings)
        {
            _userRepository = repository;
            _appSettings = appSettings.Value;
        }

        [HttpPost("register")]
        //TODO Post not working on the api side, error is unable to convert Json into User. Most likely need a register DTO then map it to USer

        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _userRepository.Get(u => u.Email == user.Email) != null)
                return BadRequest("email already exists");

            //TODO crypt user password
            //Il va falloir ajouter le cryptage à l'ajout et la modification d'un user

            var addedUser = await _userRepository.Add(user);

            if (addedUser == null)
                return BadRequest("Something went wrong");

            return CreatedAtAction(nameof(UsersController.Get), new { id = addedUser });
  

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDTO)
        {
            //TODO crypter le mdp du loginDTO pour le comparer au mdp dans la ddb (il faut aussi ajouter le cryptage dans le UserController)
            var userToLog = await _userRepository.Get(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
            if (userToLog == null)
                return Unauthorized("Email or password is incorrect");


            var role = userToLog.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, role),
                new Claim("UserId", userToLog.Id.ToString()),
            };

            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.SecretKey!)), SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                claims: claims,
                
                issuer: _appSettings.ValidIssuer,
                audience: _appSettings.ValidAudience,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddHours(4)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new LoginResponseDTO
            {
                Token = token,
                Message = "User successfuly registered",
                User = userToLog
            });


        }

        [HttpPost]
        public async Task<IActionResult> autoLogin([FromBody] string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            

            int.TryParse(jwt.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value, out int UserId);

            var user = await _userRepository.Get(u => u.Id == UserId);

            return Ok(user);
        }
    }
}
