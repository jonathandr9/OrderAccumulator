using OrderAccumulator.Domain.Models;
using OrderAccumulator.Domain.Services;

namespace OrderAccumulator.Application
{
    public class OrderService : IOrderService
    {
        public Task<FinancialExposure> CalculateFinancialExposure(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
