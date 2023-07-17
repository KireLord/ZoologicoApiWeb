//RegistroController
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZoologicoApiWeb.Data;
using ZoologicoApiWeb.Models;

namespace ZoologicoApiWeb.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly ZoologicoApiWebContext _context;

        public RegistrosController(ZoologicoApiWebContext context)
        {
            _context = context;
        }

        // GET: Registros
        public async Task<IActionResult> Index()
        {
              return _context.Registro != null ? 
                          View(await _context.Registro.ToListAsync()) :
                          Problem("Entity set 'ZoologicoApiWebContext.Registro'  is null.");
        }

        // GET: Registros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registro == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,CorreoElectronico,Contraseña")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: Registros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registro == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            return View(registro);
        }

        // POST: Registros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,CorreoElectronico,Contraseña")] Registro registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registro.Id))
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
            return View(registro);
        }

        // GET: Registros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registro == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registro == null)
            {
                return Problem("Entity set 'ZoologicoApiWebContext.Registro'  is null.");
            }
            var registro = await _context.Registro.FindAsync(id);
            if (registro != null)
            {
                _context.Registro.Remove(registro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
          return (_context.Registro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
