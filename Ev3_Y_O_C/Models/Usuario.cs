using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ev3_Y_O_C.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        // Relaci�n uno a muchos con Asignacion
        public ICollection<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();

        // Clave for�nea y propiedad de navegaci�n para Rol
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }  // Propiedad de navegaci�n para Rol
    }
}
