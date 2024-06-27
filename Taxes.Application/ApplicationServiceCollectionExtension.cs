

using Microsoft.Extensions.DependencyInjection;
using Taxes.Application.Repository;

namespace Taxes.Application
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ITaxeRepository, TaxeRepository>();
            return services;
        }
    }
}
