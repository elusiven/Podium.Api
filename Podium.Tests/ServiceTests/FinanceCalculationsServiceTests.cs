using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Podium.Service;

namespace Podium.Tests.ServiceTests
{
    [TestClass]
    public class FinanceCalculationsServiceTests
    {
        [TestMethod]
        public void CalculateLtv()
        {
            // Arrange
            var propertyValue = 250000.00m;
            var depositAmount = 50000.00m;
            var financeCalculationsService = new FinanceCalculationsService(new Logger<FinanceCalculationsService>(new LoggerFactory()));

            // Act
            var ltv = financeCalculationsService.CalculateLTVPercentage(propertyValue, depositAmount);

            // Assert
            Assert.IsNotNull(financeCalculationsService);
            Assert.AreEqual(80.0m, ltv);
        }
    }
}