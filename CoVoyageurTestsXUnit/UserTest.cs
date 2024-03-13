using CoVoyageurCore.Models;
using System.ComponentModel.DataAnnotations;

namespace CoVoyageurTestsXUnit
{
    public class UserTest
    {
        [Fact]
        public void UserValidation_ShouldFail_WhenFirstNameDoesNotStartWithUppercase()
        {
            // Arrange
            var user = new User { FirstName = "john", LastName = "DOE", Email = "john.doe@example.com", Phone = "1234567890", PassWord = "SecurePassword123!", BirthDate = DateTime.Now.AddYears(-20), Gender = "M" };

            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);

            // Assert
            Assert.False(actual);
            Assert.Contains(validationResults, vr => vr.ErrorMessage == "FirstName must start with an uppercase letter !");
        }

        [Fact]
        public void UserValidation_ShouldFail_WhenLastNameIsNotUppercase()
        {
            // Arrange
            var user = new User { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "1234567890", PassWord = "SecurePassword123!", BirthDate = DateTime.Now.AddYears(-20), Gender = "M" };

            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);

            // Assert
            Assert.False(actual);
            Assert.Contains(validationResults, vr => vr.ErrorMessage == "LastName must be in uppercase !");
        }

        [Fact]
        public void Gender_WithValidValue_ShouldPassValidation()
        {
            // Arrange
            var user = new User
            {
                FirstName = "Jane",
                LastName = "DOE",
                Email = "jane.doe@example.com",
                Phone = "1234567890",
                PassWord = "SecurePassword123!",
                BirthDate = DateTime.Now.AddYears(-20),
                Gender = "F" // Valeur valide selon la regex
            };
            var context = new ValidationContext(user, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(user, context, results, true);

            // Assert
            Assert.True(isValid);
            // Vérifie également que le message d'erreur spécifique au genre n'est pas présent
            Assert.DoesNotContain(results, r => r.ErrorMessage?.Contains("Gender must be either F, M, or N.") == true);
        }

    }
}
