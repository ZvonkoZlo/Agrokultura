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
    public class PlotsController : Controller
    {
        private readonly AgroContext _context;

        public PlotsController(AgroContext context)
        {
            _context = context;
        }

        // GET: Plots
        public async Task<IActionResult> Index()
        {
            var agroContext = _context.Plots.Include(p => p.Ground).Include(p => p.Owner).Include(p => p.Terrain);
            return View(await agroContext.ToListAsync());
        }

        // GET: Plots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plots == null)
            {
                return NotFound();
            }

            var plot = await _context.Plots
                .Include(p => p.Ground)
                .Include(p => p.Owner)
                .Include(p => p.Terrain)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plot == null)
            {
                return NotFound();
            }

            return View(plot);
        }

        // GET: Plots/Create
        public IActionResult Create()
        {
            ViewData["GroundId"] = new SelectList(_context.Grounds, "Id", "Name");
            ViewData["OwnerId"] = new SelectList(_context.People, "Id", "FullName");
            ViewData["TerrainId"] = new SelectList(_context.Terrains, "Id", "Name");
            return View();
        }

        // POST: Plots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SunPresence,GroundSlope,GroundId,TerrainId,OwnerId,PlotArea")] Plot plot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroundId"] = new SelectList(_context.Grounds, "Id", "Name", plot.GroundId);
            ViewData["OwnerId"] = new SelectList(_context.People, "Id", "FullName", plot.OwnerId);
            ViewData["TerrainId"] = new SelectList(_context.Terrains, "Id", "Name", plot.TerrainId);
            return View(plot);
        }

        // GET: Plots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plots == null)
            {
                return NotFound();
            }

            var plot = await _context.Plots.FindAsync(id);
            if (plot == null)
            {
                return NotFound();
            }
            ViewData["GroundId"] = new SelectList(_context.Grounds, "Id", "Name", plot.GroundId);
            ViewData["OwnerId"] = new SelectList(_context.People, "Id", "FullName", plot.OwnerId);
            ViewData["TerrainId"] = new SelectList(_context.Terrains, "Id", "Name", plot.TerrainId);
            return View(plot);
        }

        // POST: Plots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SunPresence,GroundSlope,GroundId,TerrainId,OwnerId,PlotArea")] Plot plot)
        {
            if (id != plot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlotExists(plot.Id))
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
            ViewData["GroundId"] = new SelectList(_context.Grounds, "Id", "Name", plot.GroundId);
            ViewData["OwnerId"] = new SelectList(_context.People, "Id", "FullName", plot.OwnerId);
            ViewData["TerrainId"] = new SelectList(_context.Terrains, "Id", "Name", plot.TerrainId);
            return View(plot);
        }

        // GET: Plots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plots == null)
            {
                return NotFound();
            }

            var plot = await _context.Plots
                .Include(p => p.Ground)
                .Include(p => p.Owner)
                .Include(p => p.Terrain)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plot == null)
            {
                return NotFound();
            }

            return View(plot);
        }

        // POST: Plots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plots == null)
            {
                return Problem("Entity set 'AgroContext.Plots'  is null.");
            }
            var plot = await _context.Plots.FindAsync(id);
            if (plot != null)
            {
                _context.Plots.Remove(plot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlotExists(int id)
        {
          return (_context.Plots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
