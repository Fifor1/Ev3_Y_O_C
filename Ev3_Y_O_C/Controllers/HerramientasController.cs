using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Ev3_Y_O_C.Data;
using Ev3_Y_O_C.Models;

namespace Ev3_Y_O_C.Controllers
{
    public class HerramientasController : Controller
    {
        private readonly AspWebContext _context;

        public HerramientasController(AspWebContext context)
        {
            _context = context;
        }

        // GET: Herramientas
        public async Task<IActionResult> Index()
        {
            var herramientas = await _context.Herramientas
                .Include(h => h.Modelo)
                .ThenInclude(m => m.Marca)
                .ToListAsync();
            return View(herramientas);
        }

        // GET: Herramientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Herramientas == null)
            {
                return NotFound();
            }

            var herramienta = await _context.Herramientas
                .Include(h => h.Modelo)
                .ThenInclude(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herramienta == null)
            {
                return NotFound();
            }

            return View(herramienta);
        }

        // GET: Herramientas/Create
        public IActionResult Create()
        {
            ViewData["Modelos"] = new SelectList(_context.ModelosHerramienta, "Id", "Nombre");
            return View();
        }

        // POST: Herramientas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroSerie,Estado,ModeloId")] Herramienta herramienta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(herramienta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Modelos"] = new SelectList(_context.ModelosHerramienta, "Id", "Nombre", herramienta.ModeloId);
            return View(herramienta);
        }

        // GET: Herramientas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Herramientas == null)
            {
                return NotFound();
            }

            var herramienta = await _context.Herramientas.FindAsync(id);
            if (herramienta == null)
            {
                return NotFound();
            }
            ViewData["Modelos"] = new SelectList(_context.ModelosHerramienta, "Id", "Nombre", herramienta.ModeloId);
            return View(herramienta);
        }

        // POST: Herramientas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroSerie,Estado,ModeloId")] Herramienta herramienta)
        {
            if (id != herramienta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(herramienta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerramientaExists(herramienta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Modelos"] = new SelectList(_context.ModelosHerramienta, "Id", "Nombre", herramienta.ModeloId);
            return View(herramienta);
        }

        // GET: Herramientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Herramientas == null)
            {
                return NotFound();
            }

            var herramienta = await _context.Herramientas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herramienta == null)
            {
                return NotFound();
            }

            return View(herramienta);
        }

        // POST: Herramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Herramientas == null)
            {
                return Problem("Entity set 'AspWebContext.Herramientas' is null.");
            }
            var herramienta = await _context.Herramientas.FindAsync(id);
            if (herramienta != null)
            {
                _context.Herramientas.Remove(herramienta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerramientaExists(int id)
        {
            return (_context.Herramientas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
