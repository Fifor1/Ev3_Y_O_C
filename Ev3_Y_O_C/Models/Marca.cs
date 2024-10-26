namespace Ev3_Y_O_C.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string NombreMarca { get; set; }

        // Relaci�n uno a muchos con ModeloHerramienta
        public ICollection<ModeloHerramienta> Modelos { get; set; } = new List<ModeloHerramienta>();
    }
}
