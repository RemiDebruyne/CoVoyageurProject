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
    public class RidesControllerTests
    {
        private readonly Mock<IRepository<Ride>> _mockRideRepo;
        private readonly Mock<IRepository<User>> _mockUserRepo;
        private readonly Mock<IRepository<Rating>> _mockRatingRepo;
        private readonly RidesController _controller;

        public RidesControllerTests()
        {
            _mockRideRepo = new Mock<IRepository<Ride>>();
            _mockUserRepo = new Mock<IRepository<User>>();
            _mockRatingRepo = new Mock<IRepository<Rating>>();
            _controller = new RidesController(_mockRideRepo.Object, _mockUserRepo.Object, _mockRatingRepo.Object);
        }

        [Fact]
        public async Task AddRide_ReturnsCreatedAtAction_WhenRideIsSuccessfullyAdded()
        {
            var newRide = new Ride
            {
                UserId = 1,
                CreationDate = DateTime.UtcNow,
                RideDate = DateTime.UtcNow.AddDays(5),
                Price = 50,
                AvailableSeats = 3,
                Departure = "City A",
                Arrival = "City B"
            };
            _mockRideRepo.Setup(x => x.Add(It.IsAny<Ride>())).ReturnsAsync(2);

            var result = await _controller.AddRide(newRide);

            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithRide()
        {
            var testRide = new Ride
            {
                Id = 1,
                UserId = 1,
                CreationDate = DateTime.UtcNow,
                RideDate = DateTime.UtcNow.AddDays(5),
                Price = 50,
                AvailableSeats = 3,
                Departure = "City A",
                Arrival = "City B"
            };
            _mockRideRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(testRide);

            var result = await _controller.Get(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Ride>(okResult.Value);
        }

        [Fact]
        public async Task UpdateRide_ReturnsOkResult_WhenRideIsUpdatedSuccessfully()
        {
            var existingRide = new Ride { Id = 1, UserId = 1, Departure = "City A", Arrival = "City B", Price = 50 };
            _mockRideRepo.Setup(x => x.GetById(1)).ReturnsAsync(existingRide);
            _mockRideRepo.Setup(x => x.Update(It.IsAny<Ride>())).ReturnsAsync(true);

            var updatedRide = existingRide;
            updatedRide.Price = 60;

            var result = await _controller.UpdateRide(1, updatedRide);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task RemoveRide_ReturnsOkResult_WhenRideIsDeletedSuccessfully()
        {
            _mockRideRepo.Setup(x => x.GetById(1)).ReturnsAsync(new Ride());
            _mockRideRepo.Setup(x => x.Delete(1)).ReturnsAsync(true);

            var result = await _controller.RemoveRide(1);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
