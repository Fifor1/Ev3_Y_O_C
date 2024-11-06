using System;

namespace Ev3_Y_O_C.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int HerramientaId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; } = new TipoMovimiento();
        public DateTime FechaMovimiento { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }

        public Herramienta? Herramienta { get; set; }
        public Usuario? Usuario { get; set; }
    }

    public enum TipoMovimiento
    {
        Ingreso,
        Asignacion,
        Mantencion,
        Retorno
    }
}
