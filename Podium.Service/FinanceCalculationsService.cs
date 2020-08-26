using Microsoft.Extensions.Logging;
using Podium.Service.Abstractions;

namespace Podium.Service
{
    public class FinanceCalculationsService : IFinanceCalculationsService
    {
        private readonly ILogger<FinanceCalculationsService> _logger;

        public FinanceCalculationsService(ILogger<FinanceCalculationsService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Calculates loan to value ratio
        /// </summary>
        /// <param name="propertyValue"></param>
        /// <param name="depositAmount"></param>
        /// <returns></returns>
        public decimal CalculateLTVPercentage(decimal propertyValue, decimal depositAmount)
        {
            _logger.LogInformation("FinanceCalculationsService::CalculateLTVPercentage");
            var amountToBorrow = propertyValue - depositAmount;
            return amountToBorrow / propertyValue * 100;
        }
    }
}