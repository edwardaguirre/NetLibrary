using PruebaIngresoBibliotecario.Application.DTOs;
using PruebaIngresoBibliotecario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application.Interfaces.Repository
{
    public interface IPrestamosRepository
    {
        Task<IEnumerable<Prestamo>> ObtenerTodosAsync();
        Task<Prestamo?> ObtenerPorUsuarioIdAsync(string IdentificacionUsuario);
        Task<Prestamo?> ObtenerPorIsbnAsync(string Isbn);
        Task<Prestamo> CrearPrestamoAsync(SolicitudPrestamoRequestDto prestamo);
        Task<Prestamo?> GetPrestamoPorIdAsync(Guid Id);

    }
}
