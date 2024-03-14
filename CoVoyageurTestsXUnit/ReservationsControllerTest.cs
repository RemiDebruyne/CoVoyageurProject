using CoVoyageurAPI.Controllers;
using CoVoyageurAPI.Repositories;
using CoVoyageurCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CoVoyageurTestsXUnit
{
    public class ReservationsControllerTests
    {
        private readonly Mock<IRepository<Reservation>> _mockReservationRepo;
        private readonly Mock<IRepository<User>> _mockUserRepo;
        private readonly Mock<IRepository<Ride>> _mockRideRepo;
        private readonly ReservationsController _controller;

        public ReservationsControllerTests()
        {
            _mockReservationRepo = new Mock<IRepository<Reservation>>();
            _mockUserRepo = new Mock<IRepository<User>>();
            _mockRideRepo = new Mock<IRepository<Ride>>();
            _controller = new ReservationsController(_mockReservationRepo.Object, _mockUserRepo.Object, _mockRideRepo.Object);
        }

        [Fact]
        public async Task AddReservation_ReturnsCreatedAtAction_WhenReservationIsSuccessfullyAdded()
        {
            var newReservation = new Reservation
            {
                UserId = 1,
                RideId = 1,
                ReservationDate = DateTime.UtcNow,
                Status = Reservation.ReservationStatus.Waiting
            };
            _mockReservationRepo.Setup(x => x.Add(It.IsAny<Reservation>())).ReturnsAsync(2);

            var result = await _controller.AddReservation(newReservation);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Reservation added", actionResult.Value);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithReservation()
        {
            var testReservationId = 1;
            var testReservation = new Reservation
            {
                Id = testReservationId,
                UserId = 1,
                RideId = 1,
                ReservationDate = DateTime.UtcNow,
                Status = Reservation.ReservationStatus.Confirmed
            };
            _mockReservationRepo.Setup(repo => repo.GetById(testReservationId)).ReturnsAsync(testReservation);

            var result = await _controller.Get(testReservationId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnReservation = Assert.IsType<Reservation>(okResult.Value);
            Assert.Equal(testReservationId, returnReservation.Id);
        }

        [Fact]
        public async Task UpdateReservation_ReturnsOkResult_WhenReservationIsUpdatedSuccessfully()
        {
            var testReservation = new Reservation
            {
                Id = 1,
                UserId = 1,
                RideId = 1,
                ReservationDate = DateTime.UtcNow,
                Status = Reservation.ReservationStatus.Cancelled
            };
            _mockReservationRepo.Setup(x => x.GetById(1)).ReturnsAsync(testReservation);
            _mockReservationRepo.Setup(x => x.Update(It.IsAny<Reservation>())).ReturnsAsync(true);

            var result = await _controller.UpdateReservation(testReservation.Id, testReservation);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Reservation Updated !", okResult.Value);
        }

        [Fact]
        public async Task RemoveReservation_ReturnsOkResult_WhenReservationIsDeletedSuccessfully()
        {
            _mockReservationRepo.Setup(x => x.GetById(1)).ReturnsAsync(new Reservation());
            _mockReservationRepo.Setup(x => x.Delete(1)).ReturnsAsync(true);

            var result = await _controller.RemoveReservation(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Reservation Deleted !", okResult.Value);
        }
    }
}
