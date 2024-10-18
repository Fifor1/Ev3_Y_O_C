namespace EjemploASPWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime Genero { get; set; }
        public string FechaNacimiento { get; set; }
        public int NumeroDeMascotas { get; set; }
    }
}