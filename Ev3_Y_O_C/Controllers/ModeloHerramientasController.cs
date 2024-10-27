using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ev3_Y_O_C.Data;
using Ev3_Y_O_C.Models;

namespace Ev3_Y_O_C.Controllers
{
    public class ModeloHerramientasController : Controller
    {
        private readonly AspWebContext _context;

        public ModeloHerramientasController(AspWebContext context)
        {
            _context = context;
        }

        // GET: ModeloHerramientas
        public async Task<IActionResult> Index()
        {
            var aspWebContext = _context.ModelosHerramientas.Include(m => m.Marca);
            return View(await aspWebContext.ToListAsync());
        }

        // GET: ModeloHerramientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelosHerramientas == null)
            {
                return NotFound();
            }

            var modeloHerramienta = await _context.ModelosHerramientas
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modeloHerramienta == null)
            {
                return NotFound();
            }

            return View(modeloHerramienta);
        }

        // GET: ModeloHerramientas/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id");
            return View();
        }

        // POST: ModeloHerramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreModelo,MarcaId")] ModeloHerramienta modeloHerramienta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloHerramienta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", modeloHerramienta.MarcaId);
            return View(modeloHerramienta);
        }

        // GET: ModeloHerramientas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelosHerramientas == null)
            {
                return NotFound();
            }

            var modeloHerramienta = await _context.ModelosHerramientas.FindAsync(id);
            if (modeloHerramienta == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", modeloHerramienta.MarcaId);
            return View(modeloHerramienta);
        }

        // POST: ModeloHerramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreModelo,MarcaId")] ModeloHerramienta modeloHerramienta)
        {
            if (id != modeloHerramienta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloHerramienta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloHerramientaExists(modeloHerramienta.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", modeloHerramienta.MarcaId);
            return View(modeloHerramienta);
        }

        // GET: ModeloHerramientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelosHerramientas == null)
            {
                return NotFound();
            }

            var modeloHerramienta = await _context.ModelosHerramientas
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modeloHerramienta == null)
            {
                return NotFound();
            }

            return View(modeloHerramienta);
        }

        // POST: ModeloHerramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelosHerramientas == null)
            {
                return Problem("Entity set 'AspWebContext.ModelosHerramientas'  is null.");
            }
            var modeloHerramienta = await _context.ModelosHerramientas.FindAsync(id);
            if (modeloHerramienta != null)
            {
                _context.ModelosHerramientas.Remove(modeloHerramienta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloHerramientaExists(int id)
        {
          return (_context.ModelosHerramientas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
