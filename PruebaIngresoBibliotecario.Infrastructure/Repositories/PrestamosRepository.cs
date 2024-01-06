using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Application.DTOs;
using PruebaIngresoBibliotecario.Application.Interfaces.Repository;
using PruebaIngresoBibliotecario.Application.Utils;
using PruebaIngresoBibliotecario.Domain.Entities;
using PruebaIngresoBibliotecario.Infrastructure.Data;

namespace PruebaIngresoBibliotecario.Infrastructure.Repositories
{
    public class PrestamosRepository : IPrestamosRepository
    {
        private readonly PersistenceContext _context;
        public enum TipoUsuarioPrestamo { AFILIADO = 1, EMPLEADO, INVITADO }

        public PrestamosRepository(PersistenceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prestamo>> ObtenerTodosAsync()
        {
            return await _context.Prestamos.ToListAsync();
        }

        public async Task<Prestamo?> ObtenerPorUsuarioIdAsync(string IdentificacionUsuario)
        {
            var response = await _context.Prestamos.Where(x => x.IdentificacionUsuario == IdentificacionUsuario).FirstOrDefaultAsync();
            return response;
        }

        public async Task<Prestamo?> ObtenerPorIsbnAsync(string Isbn)
        {
            var response = await _context.Prestamos.Where(x => x.Isbn == Isbn).FirstOrDefaultAsync();
            return response;
        }

        public async Task<Prestamo> CrearPrestamoAsync(SolicitudPrestamoRequestDto prestamo)
        {
            var response = new Prestamo
            {
                Id = Guid.NewGuid(),
                TipoUsuario = prestamo.TipoUsuario,
                IdentificacionUsuario = prestamo.IdentificacionUsuario,
                Isbn = prestamo.Isbn.ToString(),
                Activo = true,
                FechaMaximaDevolucion = Helpers.CalcularFechaEntrega(prestamo.TipoUsuario)
            };

            _context.Prestamos.Add(response);
            await _context.CommitAsync();            

            return response;
        }

        public async Task<Prestamo?> GetPrestamoPorIdAsync(Guid Id)
        {
            var response = await _context.Prestamos.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return response;
        }


    }
}
