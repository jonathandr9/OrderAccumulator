using OrderAccumulator.Domain.DbModels;

namespace OrderAccumulator.Domain.Adapters
{
    public interface IOrderSqlAdapter
    {
        Task<IEnumerable<OrderDbModel>> GetAll();
    }
}
