using Microsoft.AspNetCore.Mvc;
using OrderAccumulator.API.ViewModels;
using OrderAccumulator.Domain.Services;
using System.Net.Mime;

namespace OrderAccumulator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
                
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrderResult), 200)]
        [Produces("application/json")]
        public OrderResult Index(OrderRequest orderPost)
        {
            try
            {
                return new OrderResult();
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
