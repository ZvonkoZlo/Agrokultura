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
    public class ChoresController : Controller
    {
        private readonly AgroContext _context;

        public ChoresController(AgroContext context)
        {
            _context = context;
        }

        // GET: Chores
        public async Task<IActionResult> Index()
        {
              return _context.Chores != null ? 
                          View(await _context.Chores.ToListAsync()) :
                          Problem("Entity set 'AgroContext.Chores'  is null.");
        }

        // GET: Chores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chores == null)
            {
                return NotFound();
            }

            var chore = await _context.Chores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chore == null)
            {
                return NotFound();
            }

            return View(chore);
        }

        // GET: Chores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Duration")] Chore chore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chore);
        }

        // GET: Chores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chores == null)
            {
                return NotFound();
            }

            var chore = await _context.Chores.FindAsync(id);
            if (chore == null)
            {
                return NotFound();
            }
            return View(chore);
        }

        // POST: Chores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Duration")] Chore chore)
        {
            if (id != chore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoreExists(chore.Id))
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
            return View(chore);
        }

        // GET: Chores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chores == null)
            {
                return NotFound();
            }

            var chore = await _context.Chores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chore == null)
            {
                return NotFound();
            }

            return View(chore);
        }

        // POST: Chores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chores == null)
            {
                return Problem("Entity set 'AgroContext.Chores'  is null.");
            }
            var chore = await _context.Chores.FindAsync(id);
            if (chore != null)
            {
                _context.Chores.Remove(chore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoreExists(int id)
        {
          return (_context.Chores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
