using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderAccumulator.Domain.Models.Response;
using OrderAccumulator.Domain.Request;
using OrderAccumulator.Domain.Response;
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

        [HttpPost("exposicao-financeira")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrderResponse), 200)]
        [Produces("application/json")]
        public async Task<OrderResponse> CalculateFinancialExposure(
            OrderRequest orderPost
        )
        {
            return await _orderService
                .CalculateFinancialExposure(orderPost);
        }

        [HttpGet()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetOrdersResponse), 200)]
        [Produces("application/json")]
        public async Task<GetOrdersResponse> GetAllOrders()
        {
            return await _orderService.GetOrdersList();
        }
    }
}
