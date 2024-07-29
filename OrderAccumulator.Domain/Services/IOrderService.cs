using OrderAccumulator.Domain.Models.Response;
using OrderAccumulator.Domain.Request;
using OrderAccumulator.Domain.Response;

namespace OrderAccumulator.Domain.Services
{
    public interface IOrderService
    {
        Task<OrderResponse> CalculateFinancialExposure(OrderRequest order);
        Task<GetOrdersResponse> GetOrdersList();
    }
}
