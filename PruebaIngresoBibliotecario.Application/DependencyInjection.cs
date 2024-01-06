using Microsoft.Extensions.DependencyInjection;
using PruebaIngresoBibliotecario.Application.Interfaces.Service;
using PruebaIngresoBibliotecario.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<IPrestamoService, PrestamoService>();
            return services;
        }
    }
}
