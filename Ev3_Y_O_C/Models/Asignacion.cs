using System;

namespace Ev3_Y_O_C.Models
{
    public class Asignacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int HerramientaId { get; set; }
        public Herramienta? Herramienta { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaRetorno { get; set; }



    }
}
