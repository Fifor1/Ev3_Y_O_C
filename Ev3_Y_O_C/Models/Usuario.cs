namespace Ev3_Y_O_C.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }  
        public string Email { get; set; }  
        public string Rol { get; set; }  

        
        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}