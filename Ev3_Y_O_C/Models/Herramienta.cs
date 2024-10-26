namespace Ev3_Y_O_C.Models
{
    public class Herramienta
    {
        public int Id { get; set; }
        public string NumeroSerie { get; set; }
        public string Estado { get; set; }
        public DateTime FechaIngreso { get; set; }

        // Clave foránea y propiedad de navegación para ModeloHerramienta
        public int ModeloId { get; set; }
        public ModeloHerramienta Modelo { get; set; }

        // Relación uno a muchos con Movimiento
        public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    }
}
