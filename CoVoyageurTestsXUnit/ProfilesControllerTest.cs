using CoVoyageurAPI.Controllers;
using CoVoyageurAPI.Repositories;
using CoVoyageurCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CoVoyageurTestsXUnit
{
    public class ProfilesControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResult_WithProfile()
        {
            var mockProfileRepo = new Mock<IRepository<Profile>>();
            mockProfileRepo.Setup(repo => repo.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Profile { Id = 1, UserId = 1, Rating = 5, Review = "Great experience" });

            var profilesController = new ProfilesController(mockProfileRepo.Object, new Mock<IRepository<User>>().Object, new Mock<IRepository<Car>>().Object);

            var result = await profilesController.Get(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProfile = Assert.IsType<Profile>(okResult.Value);
            Assert.Equal(5, returnProfile.Rating);
            Assert.Equal("Great experience", returnProfile.Review);
        }

        [Fact]
        public async Task AddProfile_ReturnsCreatedAtAction_WhenProfileIsSuccessfullyAdded()
        {
            // Arrange
            var mockProfileRepo = new Mock<IRepository<Profile>>();
            var newProfile = new Profile { UserId = 1, Rating = 5, Review = "Excellent" };
            mockProfileRepo.Setup(x => x.Add(It.IsAny<Profile>())).ReturnsAsync(2);

            // Act
            var profilesController = new ProfilesController(mockProfileRepo.Object, new Mock<IRepository<User>>().Object, new Mock<IRepository<Car>>().Object);

            var result = await profilesController.AddProfile(newProfile);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Profile added", createdAtActionResult.Value);
        }

        [Fact]
        public async Task UpdateProfile_ReturnsOkResult_WhenProfileIsUpdatedSuccessfully()
        {
            var mockProfileRepo = new Mock<IRepository<Profile>>();
            var existingProfile = new Profile { Id = 1, UserId = 1, Rating = 4, Review = "Good" };

            mockProfileRepo.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(existingProfile);
            mockProfileRepo.Setup(x => x.Update(It.IsAny<Profile>())).ReturnsAsync(true);

            var profilesController = new ProfilesController(mockProfileRepo.Object, new Mock<IRepository<User>>().Object, new Mock<IRepository<Car>>().Object);

            var result = await profilesController.UpdateProfile(1, new Profile { Rating = 5, Review = "Excellent" });

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Profile Updated !", okResult.Value);
        }

        [Fact]
        public async Task RemoveProfile_ReturnsOkResult_WhenProfileIsDeletedSuccessfully()
        {
            var mockProfileRepo = new Mock<IRepository<Profile>>();
            mockProfileRepo.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Profile { Id = 1 });
            mockProfileRepo.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(true);

            var profilesController = new ProfilesController(mockProfileRepo.Object, new Mock<IRepository<User>>().Object, new Mock<IRepository<Car>>().Object);

            var result = await profilesController.RemoveProfile(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Profile Deleted !", okResult.Value);
        }
    }
}
