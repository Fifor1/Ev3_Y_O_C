using Ev3_Y_O_C.Models;
using System.Collections.Generic;

namespace Ev3_Y_O_C.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación Uno a Muchos con ModeloHerramienta
        public ICollection<ModeloHerramienta> Modelos { get; set; } = new List<ModeloHerramienta>();
    }
}
