using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Ev3_Y_O_C.Data;
using Ev3_Y_O_C.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ev3_Y_O_C.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly AspWebContext _context;

        public AsignacionesController(AspWebContext context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public async Task<IActionResult> Index()
        {
            var asignaciones = await _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Herramienta)
                .ToListAsync();
            return View(asignaciones);
        }

        // GET: Asignaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Herramienta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre");
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Nombre");
            return View();
        }

        // POST: Asignaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,HerramientaId,FechaAsignacion,FechaDevolucion")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre", asignacion.UsuarioId);
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Nombre", asignacion.HerramientaId);
            return View(asignacion);
        }

        // GET: Asignaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre", asignacion.UsuarioId);
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Nombre", asignacion.HerramientaId);
            return View(asignacion);
        }

        // POST: Asignaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,HerramientaId,FechaAsignacion,FechaDevolucion")] Asignacion asignacion)
        {
            if (id != asignacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionExists(asignacion.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre", asignacion.UsuarioId);
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Nombre", asignacion.HerramientaId);
            return View(asignacion);
        }

        // GET: Asignaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Herramienta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asignaciones == null)
            {
                return Problem("Entity set 'AspWebContext.Asignaciones' is null.");
            }
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionExists(int id)
        {
            return (_context.Asignaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
