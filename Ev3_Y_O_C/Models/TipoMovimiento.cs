using System.ComponentModel.DataAnnotations;

namespace Ev3_Y_O_C.Models
{
    public class TipoMovimiento
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}
