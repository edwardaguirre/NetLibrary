using PruebaIngresoBibliotecario.Application.DTOs;
using PruebaIngresoBibliotecario.Application.Interfaces.Repository;
using PruebaIngresoBibliotecario.Application.Interfaces.Service;
using PruebaIngresoBibliotecario.Application.Utils;

namespace PruebaIngresoBibliotecario.Application.Services
{
    public class PrestamoService : IPrestamoService
    {
        public readonly IPrestamosRepository _prestamoRepository;

        public PrestamoService(IPrestamosRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        public async Task<ConsultaPrestamoResponseDto> CrearPrestamo(SolicitudPrestamoRequestDto SolicitudPrestamoRequest)
        {
            try
            {
                if (!Helpers.ValidarExisteTipoUsuario(SolicitudPrestamoRequest.TipoUsuario))
                {
                    return new ConsultaPrestamoResponseDto
                    {
                        Exito = false,
                        Mensaje = $"El tipo de usuario {SolicitudPrestamoRequest.TipoUsuario} no existe"
                    };
                }

                var verificarPrestamo = await _prestamoRepository.ObtenerPorUsuarioIdAsync(SolicitudPrestamoRequest.IdentificacionUsuario);

                if (verificarPrestamo != null)
                {
                    var responseVerifica = new ConsultaPrestamoResponseDto
                    {
                        Exito = false,
                        Mensaje = $"El usuario con identificacion {SolicitudPrestamoRequest.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo"
                    };

                    return responseVerifica;
                }

                var response = _prestamoRepository.CrearPrestamoAsync(SolicitudPrestamoRequest);

                var responseDto = new ConsultaPrestamoResponseDto
                {
                    Exito = true,
                    Mensaje = "Se ha creado el prestamo correctamente",
                    Id = response.Result.Id,
                    FechaMaximaDevolucion = response.Result.FechaMaximaDevolucion
                };

                return responseDto;

            }
            catch (Exception)
            {
                return new ConsultaPrestamoResponseDto
                {
                    Exito = false,
                    Mensaje = $"El usuario con identificacion {SolicitudPrestamoRequest.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo"
                };
            }
        }

        public async Task<ConsultaPrestamoResponseDto> ObtenerPrestamoPorId(Guid Id)
        {
            var response = await _prestamoRepository.GetPrestamoPorIdAsync(Id);

            if (response == null)
            {
                return new ConsultaPrestamoResponseDto
                {
                    Exito = false,
                    Mensaje = $"El prestamo con id {Id} no existe"
                };
            }

            var responseDto = new ConsultaPrestamoResponseDto
            {
                Exito = true,
                Mensaje = "Se ha encontrado el prestamo correctamente",
                Id = response.Id,
                Isbn = response.Isbn,
                IdentificacionUsuario = response.IdentificacionUsuario,
                TipoUsuario = response.TipoUsuario,
                FechaMaximaDevolucion = response.FechaMaximaDevolucion
            };

            return responseDto;
        }
    }
}
