using Microsoft.EntityFrameworkCore;
using Ev3_Y_O_C.Models;


namespace Ev3_Y_O_C.Data
{
    public class AspWebContext : DbContext
    {
        public AspWebContext(DbContextOptions<AspWebContext> options) : base(options) { }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<ModeloHerramienta> ModelosHerramienta { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación Marca - ModeloHerramienta (Uno a Muchos)
            modelBuilder.Entity<Marca>()
                .HasMany(m => m.Modelos)
                .WithOne(mh => mh.Marca)
                .HasForeignKey(mh => mh.MarcaId);

            // Configuración de la relación ModeloHerramienta - Herramienta (Uno a Muchos)
            modelBuilder.Entity<ModeloHerramienta>()
                .HasMany(mh => mh.Herramientas)
                .WithOne(h => h.Modelo)
                .HasForeignKey(h => h.ModeloId);

            // Configuración de la relación Usuario - Asignacion (Uno a Muchos)
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Asignaciones)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.UsuarioId);

            // Configuración de la relación Herramienta - Asignacion (Uno a Muchos)
            modelBuilder.Entity<Herramienta>()
                .HasMany(h => h.Asignaciones)
                .WithOne(a => a.Herramienta)
                .HasForeignKey(a => a.HerramientaId);

            // Configuración de la relación Herramienta - Movimiento (Uno a Muchos)
            modelBuilder.Entity<Herramienta>()
                .HasMany(h => h.Movimientos)
                .WithOne(m => m.Herramienta)
                .HasForeignKey(m => m.HerramientaId);

            // Configuración de la relación Usuario - Movimiento (Uno a Muchos)
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Movimientos)
                .WithOne(m => m.Usuario)
                .HasForeignKey(m => m.UsuarioId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
