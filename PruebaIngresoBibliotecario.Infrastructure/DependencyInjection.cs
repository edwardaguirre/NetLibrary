using Microsoft.Extensions.DependencyInjection;
using PruebaIngresoBibliotecario.Application.Interfaces.Repository;
using PruebaIngresoBibliotecario.Infrastructure.Repositories;

namespace PruebaIngresoBibliotecario.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPrestamosRepository, PrestamosRepository>();

            return services;
        }
    }
}
