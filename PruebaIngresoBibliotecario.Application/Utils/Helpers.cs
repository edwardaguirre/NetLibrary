using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application.Utils
{
    public static class Helpers
    {
        public enum TipoUsuarioPrestamo { AFILIADO = 1, EMPLEADO, INVITADO }

        public static DateTime CalcularFechaEntrega(int tipoUsuario)
        {
            var weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var fechaDevolucion = DateTime.Now;
            var diasPrestamo = -1;

            switch (tipoUsuario)
            {
                case (int)TipoUsuarioPrestamo.AFILIADO:
                    diasPrestamo = 10;
                    break;
                case (int)TipoUsuarioPrestamo.EMPLEADO:
                    diasPrestamo = 8;
                    break;
                case (int)TipoUsuarioPrestamo.INVITADO:
                    diasPrestamo = 7;
                    break;
            }

            for (int i = 0; i < diasPrestamo;)
            {
                fechaDevolucion = fechaDevolucion.AddDays(1);
                i = (!weekend.Contains(fechaDevolucion.DayOfWeek)) ? ++i : i;
            }

            return fechaDevolucion;
        }


        public static bool ValidarExisteTipoUsuario(int tipoUsuario)
        {
            var tiposUsuario = new[] { (int)TipoUsuarioPrestamo.AFILIADO, (int)TipoUsuarioPrestamo.EMPLEADO, (int)TipoUsuarioPrestamo.INVITADO };
            return tiposUsuario.Contains(tipoUsuario);
        }
    }
}
