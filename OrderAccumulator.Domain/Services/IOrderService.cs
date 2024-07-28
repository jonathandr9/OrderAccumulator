using OrderAccumulator.Domain.Models;

namespace OrderAccumulator.Domain.Services
{
    public interface IOrderService
    {
        Task<FinancialExposure> CalculateFinancialExposure(Order order);
    }
}
