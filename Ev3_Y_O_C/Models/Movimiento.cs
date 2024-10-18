namespace Ev3_Y_O_C.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int HerramientaId { get; set; }  
        public int UsuarioId { get; set; } 
        public string TipoMovimiento { get; set; }  
        public DateTime FechaMovimiento { get; set; }  

        public Herramienta Herramienta { get; set; }  
        public Usuario Usuario { get; set; }  

    }
}