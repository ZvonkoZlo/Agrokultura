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
    public class GroundsController : Controller
    {
        private readonly AgroContext _context;

        public GroundsController(AgroContext context)
        {
            _context = context;
        }

        // GET: Grounds
        public async Task<IActionResult> Index()
        {
              return _context.Grounds != null ? 
                          View(await _context.Grounds.ToListAsync()) :
                          Problem("Entity set 'AgroContext.Grounds'  is null.");
        }

        // GET: Grounds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grounds == null)
            {
                return NotFound();
            }

            var ground = await _context.Grounds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ground == null)
            {
                return NotFound();
            }

            return View(ground);
        }

        // GET: Grounds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grounds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Ground ground)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ground);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ground);
        }

        // GET: Grounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grounds == null)
            {
                return NotFound();
            }

            var ground = await _context.Grounds.FindAsync(id);
            if (ground == null)
            {
                return NotFound();
            }
            return View(ground);
        }

        // POST: Grounds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Ground ground)
        {
            if (id != ground.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ground);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroundExists(ground.Id))
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
            return View(ground);
        }

        // GET: Grounds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grounds == null)
            {
                return NotFound();
            }

            var ground = await _context.Grounds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ground == null)
            {
                return NotFound();
            }

            return View(ground);
        }

        // POST: Grounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grounds == null)
            {
                return Problem("Entity set 'AgroContext.Grounds'  is null.");
            }
            var ground = await _context.Grounds.FindAsync(id);
            if (ground != null)
            {
                _context.Grounds.Remove(ground);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroundExists(int id)
        {
          return (_context.Grounds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
