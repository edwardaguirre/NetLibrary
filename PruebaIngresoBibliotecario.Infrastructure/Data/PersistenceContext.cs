using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaIngresoBibliotecario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Infrastructure.Data
{
    public class PersistenceContext : DbContext
    {

        private readonly IConfiguration Config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            Config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Config.GetValue<string>("SchemaName"));

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prestamo>().HasData(
                new Prestamo
                {
                    Id = Guid.NewGuid(),
                    TipoUsuario = 1,
                    IdentificacionUsuario = "123456789",
                    Isbn = "123456789",
                    Activo = true,
                    FechaMaximaDevolucion = DateTime.Now.AddDays(15)
                },
                new Prestamo
                {
                    Id = Guid.NewGuid(),
                    TipoUsuario = 2,
                    IdentificacionUsuario = "987654321",
                    Isbn = "987654321",
                    Activo = true,
                    FechaMaximaDevolucion = DateTime.Now.AddDays(15)
                },
                new Prestamo
                {
                    Id = Guid.NewGuid(),
                    TipoUsuario = 3,
                    IdentificacionUsuario = "123456789",
                    Isbn = "123456789",
                    Activo = true,
                    FechaMaximaDevolucion = DateTime.Now.AddDays(15)
                },
                new Prestamo
                {
                    Id = Guid.NewGuid(),
                    TipoUsuario = 4,
                    IdentificacionUsuario = "987654321",
                    Isbn = "987654321",
                    Activo = true,
                    FechaMaximaDevolucion = DateTime.Now.AddDays(15)
                }
             );
        }

        public DbSet<Prestamo> Prestamos { get; set; }
    }
}
