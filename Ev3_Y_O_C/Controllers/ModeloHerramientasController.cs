using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Ev3_Y_O_C.Data;
using Ev3_Y_O_C.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ev3_Y_O_C.Controllers
{
    public class ModelosHerramientaController : Controller
    {
        private readonly AspWebContext _context;

        public ModelosHerramientaController(AspWebContext context)
        {
            _context = context;
        }

        // GET: ModelosHerramienta
        public async Task<IActionResult> Index()
        {
            var modelos = await _context.ModelosHerramienta.Include(m => m.Marca).ToListAsync();
            return View(modelos);
        }

        // GET: ModelosHerramienta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelosHerramienta == null)
            {
                return NotFound();
            }

            var modelo = await _context.ModelosHerramienta
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: ModelosHerramienta/Create
        public IActionResult Create()
        {
            ViewData["Marcas"] = new SelectList(_context.Marcas, "Id", "Nombre");
            return View();
        }

        // POST: ModelosHerramienta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,MarcaId")] ModeloHerramienta modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Marcas"] = new SelectList(_context.Marcas, "Id", "Nombre", modelo.MarcaId);
            return View(modelo);
        }

        // GET: ModelosHerramienta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelosHerramienta == null)
            {
                return NotFound();
            }

            var modelo = await _context.ModelosHerramienta.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }
            ViewData["Marcas"] = new SelectList(_context.Marcas, "Id", "Nombre", modelo.MarcaId);
            return View(modelo);
        }

        // POST: ModelosHerramienta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,MarcaId")] ModeloHerramienta modelo)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloHerramientaExists(modelo.Id))
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
            ViewData["Marcas"] = new SelectList(_context.Marcas, "Id", "Nombre", modelo.MarcaId);
            return View(modelo);
        }

        // GET: ModelosHerramienta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelosHerramienta == null)
            {
                return NotFound();
            }

            var modelo = await _context.ModelosHerramienta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: ModelosHerramienta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelosHerramienta == null)
            {
                return Problem("Entity set 'AspWebContext.ModelosHerramienta' is null.");
            }
            var modelo = await _context.ModelosHerramienta.FindAsync(id);
            if (modelo != null)
            {
                _context.ModelosHerramienta.Remove(modelo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloHerramientaExists(int id)
        {
            return (_context.ModelosHerramienta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
