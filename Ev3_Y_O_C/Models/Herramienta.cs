using System;

namespace Ev3_Y_O_C.Models
{
    public class Herramienta
    {
        public int Id { get; set; }
        public string NumeroSerie { get; set; }
        public EstadoHerramienta Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int ModeloId { get; set; }

        public ModeloHerramienta Modelo { get; set; }
    }

    public enum EstadoHerramienta
    {
        Disponible,
        EnUso,
        EnMantencion
    }
}
