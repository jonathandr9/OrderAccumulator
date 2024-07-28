using FinancialExposure.DbAdapter;
using FinancialExposure.DbAdapter.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderAccumulator.Application;
using OrderAccumulator.Domain.Adapters;
using OrderAccumulator.Domain.Services;

namespace OrderAccumulator.IoC
{
    public class DependencyInjection
    {
        public static void RegisterConfigurations(
           IServiceCollection services,
           ConfigurationManager configuration)
        {

        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
        }

        public static void RegisterAdapters(IServiceCollection services)
        {
            services.AddScoped<IOrderSqlAdapter, OrderSqlAdapter>();
        }

        public static void RegisterProjectAdapters(
            IServiceCollection services,
            ConfigurationManager configuration
        )
        {
            services.AddAgendamentoOnlineSqlAdapter(
               configuration.GetSection("FinancialExposureDbAdapterConfiguration")
               .Get<FinancialExposureDbAdapterConfiguration>()
               );
        }
    }
}
