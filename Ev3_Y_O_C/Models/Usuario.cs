using System.ComponentModel.DataAnnotations.Schema;

namespace Ev3_Y_O_C.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }

        [ForeignKey("Rol")]
        public int RolId { get; set; }

    }
}