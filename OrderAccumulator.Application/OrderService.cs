using AutoMapper;
using OrderAccumulator.Domain.Adapters;
using OrderAccumulator.Domain.DbModels;
using OrderAccumulator.Domain.Models;
using OrderAccumulator.Domain.Models.Response;
using OrderAccumulator.Domain.Request;
using OrderAccumulator.Domain.Response;
using OrderAccumulator.Domain.Services;

namespace OrderAccumulator.Application
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderSqlAdapter _orderSqlAdapter;

        public OrderService(IMapper mapper,
            IOrderSqlAdapter orderSqlAdapter)
        {
            _mapper = mapper;
            _orderSqlAdapter = orderSqlAdapter;
        }

        public async Task<OrderResponse> CalculateFinancialExposure(
            OrderRequest orderPost)
        {

            var result = new FinancialExposureModel();

            try
            {
                var newOrder = _mapper.Map<OrderModel>(orderPost);

                var allOrders = _mapper.Map<List<OrderModel>>(
                    await _orderSqlAdapter.GetAll()
                );
                allOrders.Add(newOrder);

                result.ExposureValueCalc(allOrders);

                if (result.ExposureValueCheck())
                {
                    var orderToAddDb = _mapper.Map<OrderDbModel>(newOrder);
                    await _orderSqlAdapter.Add(orderToAddDb);
                }

                return _mapper.Map<OrderResponse>(result);
            }
            catch (Exception ex)
            {
                //TODO: Enhancement: Add Ex.Message to the application logs

                return new OrderResponse
                {
                    sucesso = false,
                    exposicao_atual = null,
                    msg_erro = "Ocorreu um erro ao cacular a Exposição," +
                    "entre em contato com o Administrador."
                };
            }
        }

        public async Task<GetOrdersResponse> GetOrdersList()
        {
            try
            {
                var ordersList = await _orderSqlAdapter.GetAll();

                return new GetOrdersResponse()
                {
                    sucesso = true,
                    ordens = _mapper.Map<IEnumerable<GetOrdersReponseItem>>(ordersList)
                };
            }
            catch (Exception ex)
            {
                //TODO: Enhancement: Add Ex.Message to the application logs

                return new GetOrdersResponse
                {
                    sucesso = false,
                    msg_erro = "Ocorreu um erro ao buscar Ordens"
                };
            }
        }
    }
}

