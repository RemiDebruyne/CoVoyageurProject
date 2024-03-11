using CoVoyageurAPI.DTOs;
using CoVoyageurAPI.Helpers;
using CoVoyageurCore.Models;
using CoVoyageurAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoVoyageurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly AppSettings _settings;
        private readonly string _securityKey = "clé super secrète";
        public AuthenticationController(IRepository<User> userRepository,
            IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _settings = appSettings.Value;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _userRepository.Get(u => u.Email == user.Email) != null)
                return BadRequest("Email is already taken!");

            user.PassWord = EncryptPassword(user.PassWord);
            // pour restreindre la création d'admins : isAdmin = false

            if (await _userRepository.Add(user) > 0)
                return Ok(new { id = user.Id, Message = "user created!" });
            return BadRequest("Something went wrong...");
        }

        [HttpGet("[action]/{id}")]
        //[Authorize(Policy = Constants.RoleAdmin)]
        public async Task<IActionResult> Get(int id)
        {
            User? user = await _userRepository.Get(u => u.Id == id);
            if (user == null)
                return BadRequest("User Not Found");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        {
            login.PassWord = EncryptPassword(login.PassWord);

            var user = await _userRepository.Get(u => u.Email == login.Email && u.PassWord == login.PassWord);

            if (user == null) return BadRequest("Invalid Authentication !");

            var role = user.IsAdmin ? "Admin" : "User";

            //JWT
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, Constants.RoleAdmin),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.SecretKey!)),
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(7)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                Token = token,
                Message = "Valid Authentication !",
                User = user
            });
        }


        [HttpPost("login-url-encoded")]
        public async Task<IActionResult> LoginURL([FromForm] string email, [FromForm] string password)
        {
            string encryptedPassword = EncryptPassword(password);

            var user = await _userRepository.Get(u => u.Email == email && u.PassWord == password);

            if (user == null) return BadRequest("Invalid Authentication !");

            var role = user.IsAdmin ? "Admin" : "User";

            //JWT
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, Constants.RoleAdmin),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.SecretKey!)),
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(7)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                Token = token,
                Message = "Valid Authentication !",
                User = user
            });
        }

        // possible d'ajouter les actions de crud des users ici ou dans un controlleur UserController

        [NonAction]
        private string EncryptPassword(string? password)
        // il serait plus adapté de mettre ce genre de méthode dans un service dédié au chiffrage
        {
            if (string.IsNullOrEmpty(password)) return "";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + _securityKey));
        }
    }
}
