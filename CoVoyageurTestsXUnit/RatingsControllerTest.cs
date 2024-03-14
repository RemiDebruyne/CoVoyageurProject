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
    public class RatingsControllerTests
    {
        private readonly Mock<IRepository<Rating>> _mockRatingRepo;
        private readonly Mock<IRepository<User>> _mockUserRepo;
        private readonly Mock<IRepository<Ride>> _mockRideRepo;
        private readonly RatingsController _controller;

        public RatingsControllerTests()
        {
            _mockRatingRepo = new Mock<IRepository<Rating>>();
            _mockUserRepo = new Mock<IRepository<User>>();
            _mockRideRepo = new Mock<IRepository<Ride>>();
            _controller = new RatingsController(_mockRatingRepo.Object, _mockUserRepo.Object, _mockRideRepo.Object);
        }

        [Fact]
        public async Task AddRating_ReturnsCreatedAtAction_WhenRatingIsSuccessfullyAdded()
        {
            // Arrange
            var newRating = new Rating { RideId = 1, RatingUserId = 1, RatedUserId = 2, Score = 4.5M, Comment = "Great ride!", RatingDate = DateTime.UtcNow };
            _mockRatingRepo.Setup(x => x.Add(It.IsAny<Rating>())).ReturnsAsync(2);

            // Act
            var result = await _controller.AddRating(newRating);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Rating added", actionResult.Value);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithRating()
        {
            // Arrange
            var testRatingId = 1;
            var testRating = new Rating { Id = testRatingId, RideId = 1, RatingUserId = 1, RatedUserId = 2, Score = 5.0M, Comment = "Excellent!", RatingDate = DateTime.UtcNow };
            _mockRatingRepo.Setup(repo => repo.GetById(testRatingId)).ReturnsAsync(testRating);

            // Act
            var result = await _controller.Get(testRatingId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnRating = Assert.IsType<Rating>(okResult.Value);
            Assert.Equal(testRatingId, returnRating.Id);
            Assert.Equal("Excellent!", returnRating.Comment);
        }

        [Fact]
        public async Task UpdateRating_ReturnsOkResult_WhenRatingIsUpdatedSuccessfully()
        {
            // Arrange
            var testRating = new Rating { Id = 1, RideId = 1, RatingUserId = 1, RatedUserId = 2, Score = 4.5M, Comment = "Very good!", RatingDate = DateTime.UtcNow };
            _mockRatingRepo.Setup(x => x.GetById(1)).ReturnsAsync(testRating);
            _mockRatingRepo.Setup(x => x.Update(It.IsAny<Rating>())).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateRating(testRating.Id, testRating);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Rating Updated !", okResult.Value);
        }

        [Fact]
        public async Task RemoveRating_ReturnsOkResult_WhenRatingIsDeletedSuccessfully()
        {
            // Arrange
            var testRatingId = 1;
            _mockRatingRepo.Setup(x => x.GetById(testRatingId)).ReturnsAsync(new Rating());
            _mockRatingRepo.Setup(x => x.Delete(testRatingId)).ReturnsAsync(true);

            // Act
            var result = await _controller.RemoveRating(testRatingId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Rating Deleted !", okResult.Value);
        }
    }
}