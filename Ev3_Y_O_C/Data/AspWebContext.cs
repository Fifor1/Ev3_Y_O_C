using Ev3_Y_O_C.Models;
using Microsoft.EntityFrameworkCore;

namespace Ev3_Y_O_C.Data
{
    public class AspWebContext : DbContext
    {
        public AspWebContext(DbContextOptions<AspWebContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<ModeloHerramienta> ModelosHerramientas { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Datos iniciales para Rol
            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Nombre = "Administrador" },
                new Rol { Id = 2, Nombre = "Usuario" }
            );

            // Configuración de relaciones uno a muchos

            // Rol -> Usuarios (Relación uno a muchos)
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Usuario -> Asignaciones (Relación uno a muchos)
            modelBuilder.Entity<Asignacion>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Asignaciones)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // ModeloHerramienta -> Herramientas (Relación uno a muchos)
            modelBuilder.Entity<Herramienta>()
                .HasOne(h => h.Modelo)
                .WithMany(m => m.Herramientas)
                .HasForeignKey(h => h.ModeloId)
                .OnDelete(DeleteBehavior.Cascade);

            // Marca -> ModelosHerramientas (Relación uno a muchos)
            modelBuilder.Entity<ModeloHerramienta>()
                .HasOne(m => m.Marca)
                .WithMany(ma => ma.Modelos)
                .HasForeignKey(m => m.MarcaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Herramienta -> Movimientos (Relación uno a muchos)
            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Herramienta)
                .WithMany(h => h.Movimientos)
                .HasForeignKey(m => m.HerramientaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Usuario -> Movimientos (Relación uno a muchos)
            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Usuario)
                .WithMany() // No tenemos una colección de Movimientos en Usuario
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
