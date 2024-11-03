using System.Collections.Generic;
using Ev3_Y_O_C.Models;

namespace Ev3_Y_O_C.ViewModels
{
    public class ViewmodelHerramienta

    {
        public Herramienta Herramienta { get; set; } 
        public IEnumerable<ModeloHerramienta> Modelos { get; set; } 
        public IEnumerable<Marca> Marcas { get; set; } 
    }
}

