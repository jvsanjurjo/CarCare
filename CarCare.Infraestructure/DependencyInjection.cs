using CarCare.Application.Common.Interfaces.Persistence;
using CarCare.Infraestructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarCare.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(
            this IServiceCollection services, 
            ConfigurationManager configuration)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            return services;
        }
    }
}
