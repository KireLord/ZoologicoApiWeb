using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicacionWeb_1_GG_ER.Models;
using ZoologicoApiWeb.Data;

namespace ZoologicoApiWeb.Controllers
{
    public class AddTicketsController : Controller
    {
        private readonly BDTicketContext _context;

        public AddTicketsController(BDTicketContext context)
        {
            _context = context;
        }

        // GET: AddTickets
        public async Task<IActionResult> Index()
        {
              return _context.AddTickets != null ? 
                          View(await _context.AddTickets.ToListAsync()) :
                          Problem("Entity set 'BDTicketContext.AddTickets'  is null.");
        }

        // GET: AddTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AddTickets == null)
            {
                return NotFound();
            }

            var addTickets = await _context.AddTickets
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (addTickets == null)
            {
                return NotFound();
            }

            return View(addTickets);
        }

        // GET: AddTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,Precio,Description,Fecha")] AddTickets addTickets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addTickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addTickets);
        }

        // GET: AddTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddTickets == null)
            {
                return NotFound();
            }

            var addTickets = await _context.AddTickets.FindAsync(id);
            if (addTickets == null)
            {
                return NotFound();
            }
            return View(addTickets);
        }

        // POST: AddTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,Precio,Description,Fecha")] AddTickets addTickets)
        {
            if (id != addTickets.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addTickets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddTicketsExists(addTickets.TicketId))
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
            return View(addTickets);
        }

        // GET: AddTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddTickets == null)
            {
                return NotFound();
            }

            var addTickets = await _context.AddTickets
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (addTickets == null)
            {
                return NotFound();
            }

            return View(addTickets);
        }

        // POST: AddTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddTickets == null)
            {
                return Problem("Entity set 'BDTicketContext.AddTickets'  is null.");
            }
            var addTickets = await _context.AddTickets.FindAsync(id);
            if (addTickets != null)
            {
                _context.AddTickets.Remove(addTickets);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddTicketsExists(int id)
        {
          return (_context.AddTickets?.Any(e => e.TicketId == id)).GetValueOrDefault();
        }
    }
}
