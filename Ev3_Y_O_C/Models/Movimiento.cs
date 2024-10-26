using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ev3_Y_O_C.Models
{
    public class Movimiento
    {
        public int Id { get; set; }

        // Clave for�nea para Herramienta
        public int HerramientaId { get; set; }

        // Clave for�nea para Usuario
        public int UsuarioId { get; set; }

        public string TipoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }

        // Propiedades de navegaci�n
        public Herramienta Herramienta { get; set; }
        public Usuario Usuario { get; set; }
    }
}
