using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Domain.Entities
{
    public class Prestamo
    {
        public Guid Id { get; set; }
        public int TipoUsuario { get; set; }
        public string IdentificacionUsuario { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTime? FechaMaximaDevolucion { get; set; }
    }
}
