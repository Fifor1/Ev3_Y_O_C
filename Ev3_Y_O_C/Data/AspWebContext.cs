using Microsoft.EntityFrameworkCore;
using Ev3_Y_O_C.Models;

namespace Ev3_Y_O_C.Data
{
    public class AspWebContext : DbContext
    {
        public AspWebContext(DbContextOptions<AspWebContext> options) : base(options) { }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Asignaciones)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.UsuarioId);

            modelBuilder.Entity<Asignacion>()
                .HasOne(a => a.Herramienta)
                .WithMany()
                .HasForeignKey(a => a.HerramientaId);

            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Herramienta)
                .WithMany()
                .HasForeignKey(m => m.HerramientaId);

            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Usuario)
                .WithMany()
                .HasForeignKey(m => m.UsuarioId);
        }
    }
}
