using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agrokultura.Models;

namespace Agrokultura.Controllers
{
    public class ChoreStatusController : Controller
    {
        private readonly AgroContext _context;

        public ChoreStatusController(AgroContext context)
        {
            _context = context;
        }

        // GET: ChoreStatus
        public async Task<IActionResult> Index()
        {
              return _context.ChoreStatuses != null ? 
                          View(await _context.ChoreStatuses.ToListAsync()) :
                          Problem("Entity set 'AgroContext.ChoreStatuses'  is null.");
        }

        // GET: ChoreStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChoreStatuses == null)
            {
                return NotFound();
            }

            var choreStatus = await _context.ChoreStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (choreStatus == null)
            {
                return NotFound();
            }

            return View(choreStatus);
        }

        // GET: ChoreStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChoreStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ChoreStatus choreStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(choreStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(choreStatus);
        }

        // GET: ChoreStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChoreStatuses == null)
            {
                return NotFound();
            }

            var choreStatus = await _context.ChoreStatuses.FindAsync(id);
            if (choreStatus == null)
            {
                return NotFound();
            }
            return View(choreStatus);
        }

        // POST: ChoreStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ChoreStatus choreStatus)
        {
            if (id != choreStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(choreStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoreStatusExists(choreStatus.Id))
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
            return View(choreStatus);
        }

        // GET: ChoreStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChoreStatuses == null)
            {
                return NotFound();
            }

            var choreStatus = await _context.ChoreStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (choreStatus == null)
            {
                return NotFound();
            }

            return View(choreStatus);
        }

        // POST: ChoreStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChoreStatuses == null)
            {
                return Problem("Entity set 'AgroContext.ChoreStatuses'  is null.");
            }
            var choreStatus = await _context.ChoreStatuses.FindAsync(id);
            if (choreStatus != null)
            {
                _context.ChoreStatuses.Remove(choreStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoreStatusExists(int id)
        {
          return (_context.ChoreStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
