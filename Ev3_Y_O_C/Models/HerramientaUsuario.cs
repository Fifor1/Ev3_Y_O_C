namespace Ev3_Y_O_C.Models
{
    public class HerramientaUsuario
    {
        public DateTime FechaIngreso { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreHerramienta { get; set; }
        public string Estado { get; set; }
    }


    public class HerramientaUsuarioViewModel
    {
        public  List<HerramientaUsuario>  TablaHerramientasUsuarios { get; set; }
    }

}
