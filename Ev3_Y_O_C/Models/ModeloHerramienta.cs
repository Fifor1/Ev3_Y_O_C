namespace Ev3_Y_O_C.Models
{
    public class ModeloHerramienta
    {
        public int Id { get; set; }
        public string NombreModelo { get; set; }  
        public int MarcaId { get; set; }  
        public Marca Marca { get; set; }  

        
        public ICollection<Herramienta> Herramientas { get; set; }
        
    }
}