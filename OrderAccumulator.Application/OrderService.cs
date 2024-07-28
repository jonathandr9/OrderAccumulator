using AutoMapper;
using OrderAccumulator.Domain.Adapters;
using OrderAccumulator.Domain.Models;
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

            try
            {

                //Incluir View Model Dentro do Service.
                var order = _mapper.Map<Order>(orderPost);


                var result = new FinancialExposure();

                //1. Busca as ordens salvas na exposição financeira
                var allOrders = await _orderSqlAdapter.GetAll();
                //2. Inclui a nova ordem no objeto para calculo
                //2. Realiza o calculo
                //3. Verificar se ordem aprovada Exposição < 1.000.000
                //4. Se aprovada registra a ordem
                //5. Se não aprovada rejeita a ordem
                //6. Retorna objeto de exposição financeira

                return _mapper.Map<OrderResponse>(result);
            }
            catch (Exception ex)
            {
                return new OrderResponse
                {
                    Sucesso = false,
                    Exposicao_Atual = null,
                    Msg_Erro = ex.Message
                };
            }
        }
    }
}
