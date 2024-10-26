using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ev3_Y_O_C.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        // Relación uno a muchos con Asignacion
        public ICollection<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();

        // Clave foránea y propiedad de navegación para Rol
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }  // Propiedad de navegación para Rol
    }
}
