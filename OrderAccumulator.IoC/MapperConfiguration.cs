using Microsoft.Extensions.DependencyInjection;
using OrderAccumulator.API.ViewModels;

namespace OrderAccumulator.API.Configuration
{
    public static class MapperConfiguration
    {
        public static void AddAutoMapperConfigs(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApiMapperProfile));
        }
    }
}
