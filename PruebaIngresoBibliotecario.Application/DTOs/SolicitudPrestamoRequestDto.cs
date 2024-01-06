namespace PruebaIngresoBibliotecario.Application.DTOs
{
    public class SolicitudPrestamoRequestDto
    {
        public Guid Isbn { get; set; }
        public string IdentificacionUsuario { get; set; } = string.Empty;
        public int TipoUsuario { get; set; }
    }
}
