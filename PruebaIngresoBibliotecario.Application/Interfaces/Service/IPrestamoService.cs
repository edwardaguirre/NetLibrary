using PruebaIngresoBibliotecario.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application.Interfaces.Service
{
    public interface IPrestamoService
    {
        Task<ConsultaPrestamoResponseDto> CrearPrestamo(SolicitudPrestamoRequestDto SolicitudPrestamoRequest);
        Task<ConsultaPrestamoResponseDto> ObtenerPrestamoPorId(Guid Id);

    }
}
