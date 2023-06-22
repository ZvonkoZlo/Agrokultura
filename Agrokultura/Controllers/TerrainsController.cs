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
    public class TerrainsController : Controller
    {
        private readonly AgroContext _context;

        public TerrainsController(AgroContext context)
        {
            _context = context;
        }

        // GET: Terrains
        public async Task<IActionResult> Index()
        {
              return _context.Terrains != null ? 
                          View(await _context.Terrains.ToListAsync()) :
                          Problem("Entity set 'AgroContext.Terrains'  is null.");
        }

        // GET: Terrains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Terrains == null)
            {
                return NotFound();
            }

            var terrain = await _context.Terrains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terrain == null)
            {
                return NotFound();
            }

            return View(terrain);
        }

        // GET: Terrains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Terrains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Terrain terrain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terrain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terrain);
        }

        // GET: Terrains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Terrains == null)
            {
                return NotFound();
            }

            var terrain = await _context.Terrains.FindAsync(id);
            if (terrain == null)
            {
                return NotFound();
            }
            return View(terrain);
        }

        // POST: Terrains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Terrain terrain)
        {
            if (id != terrain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terrain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerrainExists(terrain.Id))
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
            return View(terrain);
        }

        // GET: Terrains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Terrains == null)
            {
                return NotFound();
            }

            var terrain = await _context.Terrains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terrain == null)
            {
                return NotFound();
            }

            return View(terrain);
        }

        // POST: Terrains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Terrains == null)
            {
                return Problem("Entity set 'AgroContext.Terrains'  is null.");
            }
            var terrain = await _context.Terrains.FindAsync(id);
            if (terrain != null)
            {
                _context.Terrains.Remove(terrain);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerrainExists(int id)
        {
          return (_context.Terrains?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
