using Ev3_Y_O_C.Models;
using System.Collections.Generic;

namespace Ev3_Y_O_C.Models
{
    public class ModeloHerramienta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Foreign Key y relación con Marca
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        // Relación Uno a Muchos con Herramienta
        public ICollection<Herramienta> Herramientas { get; set; } = new List<Herramienta>();
    }
}
