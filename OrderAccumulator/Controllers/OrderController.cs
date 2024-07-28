using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderAccumulator.API.ViewModels;
using OrderAccumulator.Domain.Models;
using OrderAccumulator.Domain.Services;
using System.Net.Mime;

namespace OrderAccumulator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderService orderService,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost("CalculoExposicaoFinanceira")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrderResult), 200)]
        [Produces("application/json")]
        public async Task<OrderResult> FinancialExposure(
            OrderRequest orderPost
        )
        {
            try
            {
                var order = _mapper.Map<Order>(orderPost);

                var result = await _orderService
                    .CalculateFinancialExposure(order);

                return _mapper.Map<OrderResult>(result);
            }
            catch (Exception ex)
            {
                return new OrderResult{
                    Sucesso = false,
                    Exposicao_Atual = null,
                    Msg_Erro = ex.Message
                };
            }
        }
    }
}
