namespace Ev3_Y_O_C.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación uno a muchos entre Rol y Usuario, o sea, un rol puede estar asignado a muchos usuarios
        public ICollection<Usuario> Usuarios { get; set; }
    }
}