using System;

namespace PruebaIngresoBibliotecario.Application.DTOs
{
    public class ConsultaPrestamoResponseDto
    {
        public Guid? Id { get; set; } = Guid.Empty;
        public bool Exito { get; set; }
        public string Isbn { get; set; } = string.Empty;
        public int TipoUsuario { get; set; }
        public string IdentificacionUsuario { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public DateTime? FechaMaximaDevolucion { get; set; }
    }
}
