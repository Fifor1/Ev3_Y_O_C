using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ev3_Y_O_C.Models
{
    public class Movimiento
    {
        public int Id { get; set; }

        // Clave foránea para Herramienta
        public int HerramientaId { get; set; }

        // Clave foránea para Usuario
        public int UsuarioId { get; set; }

        public string TipoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }

        // Propiedades de navegación
        public Herramienta Herramienta { get; set; }
        public Usuario Usuario { get; set; }
    }
}
