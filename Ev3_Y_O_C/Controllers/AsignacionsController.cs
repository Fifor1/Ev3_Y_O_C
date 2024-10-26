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
    public class AsignacionsController : Controller
    {
        private readonly AspWebContext _context;

        public AsignacionsController(AspWebContext context)
        {
            _context = context;
        }

        // GET: Asignacions
        public async Task<IActionResult> Index()
        {
            var aspWebContext = _context.Asignaciones.Include(a => a.Herramienta).Include(a => a.Usuario);
            return View(await aspWebContext.ToListAsync());
        }

        // GET: Asignacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Herramienta)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // GET: Asignacions/Create
        public IActionResult Create()
        {
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Asignacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HerramientaId,UsuarioId,FechaAsignacion,FechaDevolucion")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Id", asignacion.HerramientaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", asignacion.UsuarioId);
            return View(asignacion);
        }


        public async Task<IActionResult> Asignar(int usuarioId, int herramientaId)
        {
            var asignacionesActivas = await _context.Asignaciones
                .Where(a => a.UsuarioId == usuarioId && a.FechaDevolucion == null)
                .CountAsync();

            if (asignacionesActivas >= 3)
            {
                return BadRequest("El usuario ya tiene tres herramientas asignadas activas.");
            }


            // GET: Asignacions/Edit/5
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
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Id", asignacion.HerramientaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", asignacion.UsuarioId);
            return View(asignacion);
        }

        // POST: Asignacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HerramientaId,UsuarioId,FechaAsignacion,FechaDevolucion")] Asignacion asignacion)
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
            ViewData["HerramientaId"] = new SelectList(_context.Herramientas, "Id", "Id", asignacion.HerramientaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", asignacion.UsuarioId);
            return View(asignacion);
        }

        // GET: Asignacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Herramienta)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asignaciones == null)
            {
                return Problem("Entity set 'AspWebContext.Asignaciones'  is null.");
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
