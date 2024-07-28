using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderAccumulator.Application;
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
        }

        public static void RegisterProjectAdapters(
            IServiceCollection services,
            ConfigurationManager configuration
        )
        {
        }
    }
}
