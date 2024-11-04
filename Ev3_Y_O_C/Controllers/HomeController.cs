using Ev3_Y_O_C.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ev3_Y_O_C.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Crear e inicializar el ViewModel con datos de ejemplo en la lista
            var herramientaUsuarioViewModel = new HerramientaUsuarioViewModel
            {
                TablaHerramientasUsuarios = new List<HerramientaUsuario>
                {
                    new HerramientaUsuario
                    {
                        FechaIngreso = DateTime.Now,
                        NombreUsuario = "Cualquier nombre",
                        NombreHerramienta = "Cualquier herramienta",
                        Estado = "Un estado"
                    }
                }   
            };

            // Pasar el modelo a la vista
            return View(herramientaUsuarioViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
