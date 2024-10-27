using Ev3_Y_O_C.Models;
using System.Collections.Generic;

namespace Ev3_Y_O_C.Models
{
    public enum TipoMovimiento
    {
        Ingreso,
        Mantenimiento,
        Devolucion
    }

    public class Movimiento
    {
        public int Id { get; set; }
        public TipoMovimiento Tipo { get; set; }
        public DateTime Fecha { get; set; }

        // Foreign Key y relación con Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Foreign Key y relación con Herramienta
        public int HerramientaId { get; set; }
        public Herramienta Herramienta { get; set; }
    }
}
