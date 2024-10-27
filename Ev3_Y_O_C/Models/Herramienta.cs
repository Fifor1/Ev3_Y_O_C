using Ev3_Y_O_C.Models;
using System.Collections.Generic;

namespace Ev3_Y_O_C.Models
{
    public enum EstadoHerramienta
    {
        Disponible,
        EnUso,
        EnMantencion
    }

    public class Herramienta
    {
        public int Id { get; set; }
        public string NumeroSerie { get; set; }
        public EstadoHerramienta Estado { get; set; }

        // Foreign Key y relación con ModeloHerramienta
        public int ModeloId { get; set; }
        public ModeloHerramienta Modelo { get; set; }

        // Relación Uno a Muchos con Asignacion y Movimiento
        public ICollection<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();
        public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    }
}
