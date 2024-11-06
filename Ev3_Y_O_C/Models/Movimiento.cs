using Ev3_Y_O_C.Models;

public class Movimiento
{
    public int Id { get; set; }
    public int HerramientaId { get; set; }
    public int TipoMovimientoId { get; set; } // Cambia el enum por una FK
    public DateTime FechaMovimiento { get; set; } = DateTime.Now;
    public int UsuarioId { get; set; }

    public Herramienta? Herramienta { get; set; }
    public Usuario? Usuario { get; set; }
    public TipoMovimiento? TipoMovimiento { get; set; } // Navegación a TipoMovimiento

}
