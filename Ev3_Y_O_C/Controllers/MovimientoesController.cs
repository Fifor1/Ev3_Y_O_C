using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Ev3_Y_O_C.Data;
using Ev3_Y_O_C.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ev3_Y_O_C.Controllers
{
    public class MovimientosController : Controller
    {
        private readonly AspWebContext _context;

        public MovimientosController(AspWebContext context)
        {
            _context = context;
        }

        // GET: Movimientos
        public async Task<IActionResult> Index()
        {
            var movimientos = await _context.Movimientos
                .Include(m => m.Usuario)
                .Include(m => m.Herramienta)
                .ToListAsync();
            return View(movimientos);
        }

        // GET: Movimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos
                .Include(m => m.Usuario)
                .Include(m => m.Herramienta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // GET: Movimientos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre");
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Nombre");
            return View();
        }

        // POST: Movimientos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,HerramientaId,FechaMovimiento")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre", movimiento.UsuarioId);
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Nombre", movimiento.HerramientaId);
            return View(movimiento);
        }

        // GET: Movimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre", movimiento.UsuarioId);
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Nombre", movimiento.HerramientaId);
            return View(movimiento);
        }

        // POST: Movimientos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,HerramientaId,FechaMovimiento")] Movimiento movimiento)
        {
            if (id != movimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoExists(movimiento.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre", movimiento.UsuarioId);
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Nombre", movimiento.HerramientaId);
            return View(movimiento);
        }

        // GET: Movimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos
                .Include(m => m.Usuario)
                .Include(m => m.Herramienta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // POST: Movimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movimientos == null)
            {
                return Problem("Entity set 'AspWebContext.Movimientos' is null.");
            }
            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento != null)
            {
                _context.Movimientos.Remove(movimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoExists(int id)
        {
            return (_context.Movimientos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
