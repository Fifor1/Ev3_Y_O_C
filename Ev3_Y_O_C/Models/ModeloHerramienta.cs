namespace Ev3_Y_O_C.Models
{
    public class ModeloHerramienta
    {
        public int Id { get; set; }
        public string NombreModelo { get; set; }

        // Clave foránea y propiedad de navegación para Marca
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        // Relación uno a muchos con Herramienta
        public ICollection<Herramienta> Herramientas { get; set; } = new List<Herramienta>();
    }
}
