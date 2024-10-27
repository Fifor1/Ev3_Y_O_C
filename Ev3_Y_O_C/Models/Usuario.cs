using Ev3_Y_O_C.Models;
using System.Collections.Generic;

namespace Ev3_Y_O_C.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        // Relación Uno a Muchos con Asignacion y Movimiento
        public ICollection<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();
        public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    }
}
