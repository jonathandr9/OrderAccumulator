using AutoMapper;
using OrderAccumulator.Domain.DbModels;
using OrderAccumulator.Domain.Models;
using OrderAccumulator.Domain.Models.Response;
using OrderAccumulator.Domain.Request;
using OrderAccumulator.Domain.Response;

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
            CreateMap<OrderRequest, OrderModel>()
                .ForMember(d => d.Asset, m => m.MapFrom(s => s.Ativo))
                .ForMember(d => d.Side, m => m.MapFrom(s => s.Lado))
                .ForMember(d => d.Quantity, m => m.MapFrom(s => s.Quantidade))
                .ForMember(d => d.Price, m => m.MapFrom(s => s.Preco));

            CreateMap<FinancialExposureModel, OrderResponse>()
                .ForMember(d => d.sucesso, m => m.MapFrom(s => s.Success))
                .ForMember(d => d.exposicao_atual, m => m.MapFrom(s => s.ExposureValue))
                .ForMember(d => d.msg_erro, m => m.MapFrom(s => MsgFinancialExposureTreat(s.Success)));

            CreateMap<OrderDbModel, OrderModel>();

            CreateMap<OrderModel, OrderDbModel>()
                .ForMember(d => d.Date, m => m.MapFrom(s => DateTime.Now.ToString()));

            CreateMap<OrderDbModel, GetOrdersReponseItem>()
                .ForMember(d => d.ativo, m => m.MapFrom(s => s.Asset))
                .ForMember(d => d.lado, m => m.MapFrom(s => s.Side))
                .ForMember(d => d.quantidade, m => m.MapFrom(s => s.Quantity))
                .ForMember(d => d.data, m => m.MapFrom(s => s.Date))
                .ForMember(d => d.preco, m => m.MapFrom(s => s.Price));
        }

        #region "HelperMethods"
        private string MsgFinancialExposureTreat(bool success)
        {
            var result = String.Empty;

            if (success)
                return "Nova Ordem Adicionada com Sucesso!";
            else
                return "Valor da Ordem Atual Excede o Limite de Exposição Financeira!";
        }
        #endregion

    }
}
