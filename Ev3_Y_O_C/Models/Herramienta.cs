namespace Ev3_Y_O_C.Models
{
    public class Herramienta
    {
        public int Id { get; set; }
        public string NumeroSerie { get; set; }
        public string Estado { get; set; }
        public DateTime FechaIngreso { get; set; }

        // Clave for�nea y propiedad de navegaci�n para ModeloHerramienta
        public int ModeloId { get; set; }
        public ModeloHerramienta Modelo { get; set; }

        // Relaci�n uno a muchos con Movimiento
        public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    }
}
