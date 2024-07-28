using FinancialExposure.DbAdapter.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FinancialExposureDbAdapterDependencyInjection
    {
        public static IServiceCollection AddAgendamentoOnlineSqlAdapter(
            this IServiceCollection services,
            FinancialExposureDbAdapterConfiguration configuration
            )
        {
            if (services == null)
                throw new ArgumentNullException(
                    nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(
                    nameof(configuration));

            services.AddSingleton(configuration);
            services.AddSingleton
                (d => new FinancialExposureDbAdapterContext
                (configuration.SqlConnectionString));

            return services;
        }
    }
}
