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
    public class UsersControllerTests
    {
        private readonly Mock<IRepository<User>> _mockUserRepo;
        private readonly Mock<IRepository<Rating>> _mockRatingRepo;
        private readonly Mock<IRepository<Profile>> _mockProfileRepo;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _mockUserRepo = new Mock<IRepository<User>>();
            _mockRatingRepo = new Mock<IRepository<Rating>>();
            _mockProfileRepo = new Mock<IRepository<Profile>>();
            _controller = new UsersController(_mockUserRepo.Object, _mockRatingRepo.Object, _mockProfileRepo.Object);
        }

        [Fact]
        public async Task AddUser_ReturnsCreatedAtAction_WhenUserIsSuccessfullyAdded()
        {
            var newUser = new User
            {
                FirstName = "John",
                LastName = "DOE",
                Email = "john.doe@example.com",
                Phone = "1234567890",
                PassWord = "SecurePassword123!",
                BirthDate = new DateTime(1990, 1, 1),
                Gender = "M"
            };
            _mockUserRepo.Setup(x => x.Add(It.IsAny<User>())).ReturnsAsync(2);

            var result = await _controller.AddUser(newUser);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("User added", createdAtActionResult.Value);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithUser()
        {
            var testUserId = 1;
            var testUser = new User
            {
                Id = testUserId,
                FirstName = "Jane",
                LastName = "DOE",
                Email = "jane.doe@example.com"
            };
            _mockUserRepo.Setup(repo => repo.GetById(testUserId)).ReturnsAsync(testUser);

            var result = await _controller.Get(testUserId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal(testUserId, returnUser.Id);
        }

        [Fact]
        public async Task UpdateUser_ReturnsOkResult_WhenUserIsUpdatedSuccessfully()
        {
            var existingUser = new User { Id = 1, FirstName = "John", LastName = "DOE", Email = "john.doe@example.com" };
            _mockUserRepo.Setup(x => x.GetById(1)).ReturnsAsync(existingUser);
            _mockUserRepo.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync(true);

            var result = await _controller.UpdateUser(existingUser.Id, existingUser);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("User Updated !", okResult.Value);
        }

        [Fact]
        public async Task RemoveUser_ReturnsOkResult_WhenUserIsDeletedSuccessfully()
        {
            _mockUserRepo.Setup(x => x.GetById(1)).ReturnsAsync(new User { Id = 1 });
            _mockUserRepo.Setup(x => x.Delete(1)).ReturnsAsync(true);

            var result = await _controller.RemoveUser(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("User Deleted !", okResult.Value);
        }
    }
}
