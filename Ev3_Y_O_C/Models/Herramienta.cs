using System;

namespace Ev3_Y_O_C.Models
{
    public class Herramienta
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? NumeroSerie { get; set; }
        public string Modelo { get; set; }
        public int IdMarca { get; set; }
        public Marca? Marca { get; set; }
        public string Estado { get; set; } = "disponible";
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
    }

}
