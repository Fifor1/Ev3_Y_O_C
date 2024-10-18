namespace Ev3_Y_O_C.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string NombreMarca { get; set; }  

       
        public ICollection<ModeloHerramienta> Modelos { get; set; }
    }
}
