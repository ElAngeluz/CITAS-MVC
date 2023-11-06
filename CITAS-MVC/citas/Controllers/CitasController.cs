using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using citas.Models;
using citas.Models.Entities;

namespace citas.Controllers
{
    public class CitasController : Controller
    {
        private readonly CitasContext _context;

        public CitasController(CitasContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var citasContext = _context.CitaMedica.Include(c => c.PacienteNav);
            return View(await citasContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CitaMedica == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedica
                .Include(c => c.PacienteNav)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaMedica == null)
            {
                return NotFound();
            }

            return View(citaMedica);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Cedula");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Notas,Titulo,Descripcion,Codigo,Fecha,PacienteId")] CitaMedica citaMedica)
        {
            if (ModelState.IsValid)
            {
                citaMedica.Id = Guid.NewGuid();
                _context.Add(citaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Cedula", citaMedica.PacienteId);
            return View(citaMedica);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CitaMedica == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedica.FindAsync(id);
            if (citaMedica == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Cedula", citaMedica.PacienteId);
            return View(citaMedica);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Notas,Titulo,Descripcion,Codigo,Fecha,PacienteId")] CitaMedica citaMedica)
        {
            if (id != citaMedica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citaMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaMedicaExists(citaMedica.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Cedula", citaMedica.PacienteId);
            return View(citaMedica);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CitaMedica == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedica
                .Include(c => c.PacienteNav)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaMedica == null)
            {
                return NotFound();
            }

            return View(citaMedica);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CitaMedica == null)
            {
                return Problem("Entity set 'CitasContext.CitaMedica'  is null.");
            }
            var citaMedica = await _context.CitaMedica.FindAsync(id);
            if (citaMedica != null)
            {
                _context.CitaMedica.Remove(citaMedica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaMedicaExists(Guid id)
        {
          return (_context.CitaMedica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
