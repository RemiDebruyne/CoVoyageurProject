using CoVoyageurCore.Models;
using CoVoyageurAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoVoyageurAPI.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    //[Authorize(Policy = Constants.PolicyAdmin)]
    public class ReservationsController : ControllerBase
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Ride> _rideRepository;


        public ReservationsController(IRepository<Reservation> reservationRepository,
                                IRepository<User> userRepository,
                                IRepository<Ride> rideRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _rideRepository = rideRepository;
        }

        [HttpGet]
        //[Authorize(Roles = Constants.RoleUser+","+Constants.RoleAdmin)]
        public async Task<IActionResult> Menu()
        {
            return Ok(await _reservationRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _reservationRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
        {
            var reservationId = await _reservationRepository.Add(reservation);

            if (reservationId > 1)
                return CreatedAtAction(nameof(Menu), "Reservation added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] Reservation reservation)
        {
            var reservatio = await _reservationRepository.GetById(id);
            if (reservatio == null)
                return BadRequest("Reservation not found");

            reservation.Id = id;
            if (await _reservationRepository.Update(reservation))
                return Ok("Reservation Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReservation(int id)
        {
            var reservatio = await _reservationRepository.GetById(id);
            if (reservatio == null)
                return BadRequest("Reservation not found");

            if (await _reservationRepository.Delete(id))
                return Ok("Reservation Updated !");

            return BadRequest("Something went wrong...");
        }
    }
}
