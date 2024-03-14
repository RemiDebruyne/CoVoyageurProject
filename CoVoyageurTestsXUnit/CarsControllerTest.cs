using CoVoyageurAPI.Controllers;
using CoVoyageurAPI.Repositories;
using CoVoyageurCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace CoVoyageurTestsXUnit
{
    public class CarsControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResult_WithCar()
        {
            // Arrange
            var mockCarRepository = new Mock<IRepository<Car>>();
            var mockUserRepository = new Mock<IRepository<User>>();
            mockCarRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Car { Id = 1, LicensePlate = "123ABC", Model = "Model S", Brand = "Tesla", UserId = 1 });

            var controller = new CarsController(mockCarRepository.Object, mockUserRepository.Object);

            // Act
            var result = await controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCar = Assert.IsType<Car>(okResult.Value);
            Assert.Equal(1, returnCar.Id);
            Assert.Equal("123ABC", returnCar.LicensePlate);
        }

        [Fact]
        public async Task AddCar_ReturnsCreatedAtAction_WhenCarIsSuccessfullyAdded()
        {
            var mockCarRepo = new Mock<IRepository<Car>>();
            var mockUserRepo = new Mock<IRepository<User>>();
            var newCar = new Car { LicensePlate = "ABC123", Model = "Civic", Brand = "Honda", UserId = 1 };

            mockCarRepo.Setup(x => x.Add(It.IsAny<Car>())).ReturnsAsync(2);

            var controller = new CarsController(mockCarRepo.Object, mockUserRepo.Object);

            var result = await controller.AddCar(newCar);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Car added", actionResult.Value);
        }

        [Fact]
        public async Task UpdateCar_ReturnsOkResult_WhenCarIsUpdatedSuccessfully()
        {
            var mockCarRepo = new Mock<IRepository<Car>>();
            var mockUserRepo = new Mock<IRepository<User>>();
            var existingCar = new Car { Id = 1, LicensePlate = "ABC123", Model = "Civic", Brand = "Honda", UserId = 1 };

            mockCarRepo.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(existingCar);
            mockCarRepo.Setup(x => x.Update(It.IsAny<Car>())).ReturnsAsync(true);

            var controller = new CarsController(mockCarRepo.Object, mockUserRepo.Object);

            var result = await controller.UpdateCar(1, existingCar);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Car Updated !", okResult.Value);
        }

        [Fact]
        public async Task RemoveCar_ReturnsOkResult_WhenCarIsDeletedSuccessfully()
        {
            var mockCarRepo = new Mock<IRepository<Car>>();
            var mockUserRepo = new Mock<IRepository<User>>();
            mockCarRepo.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Car());
            mockCarRepo.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(true);

            var controller = new CarsController(mockCarRepo.Object, mockUserRepo.Object);

            var result = await controller.RemoveCar(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Car Deleted !", okResult.Value);
        }
    }
}
