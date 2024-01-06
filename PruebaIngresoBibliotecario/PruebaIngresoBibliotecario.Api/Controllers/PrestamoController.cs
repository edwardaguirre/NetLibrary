using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Application.DTOs;
using PruebaIngresoBibliotecario.Application.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        public readonly IPrestamoService _prestamoService;
        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPrestamo([FromBody] SolicitudPrestamoRequestDto SolicitudPrestamoRequest)
        {
            var response = await _prestamoService.CrearPrestamo(SolicitudPrestamoRequest);

            if (!response.Exito)
            {
                return BadRequest(new { mensaje = response.Mensaje });
            }

            var responseExito = new
            {
                id = response.Id,
                fechaMaximaDevolucion = response.FechaMaximaDevolucion
            };

            return Ok(responseExito);
        }

        [HttpGet("{IdPrestamo}")]
        public async Task<IActionResult> ObtenerPrestamoPorId(Guid IdPrestamo)
        {
            var response = await _prestamoService.ObtenerPrestamoPorId(IdPrestamo);

            if (response == null || !response.Exito)
            {
                return NotFound(new { mensaje = $"El prestamo con id {IdPrestamo} no existe" });
            }

            var responseExito = new
            {
                id = response.Id,
                isbn = response.Isbn,
                identificacionUsuario = response.IdentificacionUsuario,
                tipoUsuario = response.TipoUsuario,
                fechaMaximaDevolucion = response.FechaMaximaDevolucion
            };

            return Ok(responseExito);
        }

    }
}
