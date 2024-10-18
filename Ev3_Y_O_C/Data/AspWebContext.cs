using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Ev3_Y_O_C.Data
{
    public class AspWebContext : DbContext
    {
        public AspWebContext(DbContextOptions<AspWebContext> options) : base(options)
        {
        }

        public DbSet<Ev3_Y_O_C.Models.Usuario> Usuarios { get; set; }  
        public DbSet<Ev3_Y_O_C.Models.Herramienta> Herramientas { get; set; }  
        public DbSet<Ev3_Y_O_C.Models.ModeloHerramienta> ModelosHerramientas { get; set; }  
        public DbSet<Ev3_Y_O_C.Models.Marca> Marcas { get; set; }  
        public DbSet<Ev3_Y_O_C.Models.Asignacion> Asignaciones { get; set; }  
        public DbSet<Ev3_Y_O_C.Models.Movimiento> Movimientos { get; set; }  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Asegura que el número de serie sea único
            modelBuilder.Entity<Herramienta>()
                .HasIndex(h => h.NumeroSerie)
                .IsUnique();

            // Configuración de relaciones
            modelBuilder.Entity<Herramienta>()
                .HasOne(h => h.Modelo)
                .WithMany(m => m.Herramientas)
                .HasForeignKey(h => h.ModeloId);

            modelBuilder.Entity<Asignacion>()
                .HasOne(a => a.Herramienta)
                .WithMany(h => h.Asignaciones)
                .HasForeignKey(a => a.HerramientaId);

            modelBuilder.Entity<Asignacion>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Asignaciones)
                .HasForeignKey(a => a.UsuarioId);

            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Herramienta)
                .WithMany(h => h.Movimientos)
                .HasForeignKey(m => m.HerramientaId);

            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Movimientos)
                .HasForeignKey(m => m.UsuarioId);

            // Relación Marca - Modelo
            modelBuilder.Entity<ModeloHerramienta>()
                .HasOne(m => m.Marca)
                .WithMany(m => m.Modelos)
                .HasForeignKey(m => m.MarcaId);
        }
    }
}