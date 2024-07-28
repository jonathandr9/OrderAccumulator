using AutoMapper;
using OrderAccumulator.Domain.Models;
using OrderAccumulator.Domain.Request;

namespace OrderAccumulator.API.ViewModels
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            OrderMapper();
        }

        private void OrderMapper()
        {
            CreateMap<OrderRequest, Order>()
                .ForMember(d => d.Asset, m => m.MapFrom(s => s.Ativo))
                .ForMember(d => d.Side, m => m.MapFrom(s => s.Lado))
                .ForMember(d => d.Quantity, m => m.MapFrom(s => s.Quantidade))
                .ForMember(d => d.Price, m => m.MapFrom(s => s.Preco));
        }

    }
}
