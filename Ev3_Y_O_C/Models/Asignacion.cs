using Ev3_Y_O_C.Models;
using System.Collections.Generic;

namespace Ev3_Y_O_C.Models
{
    public class Asignacion
    {
        public int Id { get; set; }

        // Foreign Key y relación con Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Foreign Key y relación con Herramienta
        public int HerramientaId { get; set; }
        public Herramienta Herramienta { get; set; }

        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaDevolucion { get; set; }  // Fecha cuando se devuelve la herramienta
    }
}
