using System.Collections.Generic;

namespace Ev3_Y_O_C.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación uno a muchos con Usuario
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>(); // Iniciamos la colección
    }
}
