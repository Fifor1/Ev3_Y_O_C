namespace Ev3_Y_O_C.Models
{
    public class ModeloHerramienta
    {
        public int Id { get; set; }
        public string NombreModelo { get; set; }

        // Clave for�nea y propiedad de navegaci�n para Marca
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        // Relaci�n uno a muchos con Herramienta
        public ICollection<Herramienta> Herramientas { get; set; } = new List<Herramienta>();
    }
}
