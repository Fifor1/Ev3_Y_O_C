using Ev3_Y_O_C.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Ev3_Y_O_C.Data;

namespace Ev3_Y_O_C.Controllers
{
    public class HomeController : Controller
    {
        private readonly AspWebContext _context;

        public HomeController(AspWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var herramientas = _context.Herramientas.ToList(); // Obtener todas las herramientas
            var totalHerramientas = herramientas.Count;
            var herramientasEnUso = herramientas.Count(h => h.Estado.ToLower() == "en uso");
            var enMantenimiento = herramientas.Count(h => h.Estado.ToLower() == "en mantencion");
            var disponibles = herramientas.Count(h => h.Estado.ToLower() == "disponible");

            ViewData["TotalHerramientas"] = totalHerramientas;
            ViewData["HerramientasEnUso"] = herramientasEnUso;
            ViewData["EnMantenimiento"] = enMantenimiento;
            ViewData["Disponibles"] = disponibles;

            return View(herramientas); // Pasamos la lista de herramientas a la vista
        }
    }

    public class HerramientasViewModel
    {
        public int TotalHerramientas { get; set; }
        public int HerramientasEnUso { get; set; }
        public int EnMantenimiento { get; set; }
        public int Disponibles { get; set; }
        public List<Herramienta> Herramientas { get; set; }
    }
}
