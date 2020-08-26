using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Podium.Service;

namespace Podium.Tests.ServiceTests
{
    [TestClass]
    public class ValidationServiceTests
    {
        [TestMethod]
        public void CheckAdultAge()
        {
            // Arrange
            DateTime birthday = new DateTime(1994, 06, 13);
            var validationService = new ValidationService();

            // Act
            var result = validationService.ValidateAdultAge(birthday);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckUnderAge()
        {
            // Arrange
            DateTime birthday = new DateTime(2014, 06, 13);
            var validationService = new ValidationService();

            // Act
            var result = validationService.ValidateAdultAge(birthday);

            // Assert
            Assert.IsFalse(result);
        }
    }
}