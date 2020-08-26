namespace Podium.Service.Abstractions
{
    public interface IFinanceCalculationsService
    {
        decimal CalculateLTVPercentage(decimal propertyValue, decimal depositAmount);
    }
}