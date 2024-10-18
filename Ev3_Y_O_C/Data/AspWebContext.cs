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
           
        }
    }
}