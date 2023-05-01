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
    public class ContractPlotsController : Controller
    {
        private readonly AgroContext _context;

        public ContractPlotsController(AgroContext context)
        {
            _context = context;
        }

        // GET: ContractPlots
        public async Task<IActionResult> Index()
        {
            var agroContext = _context.ContractPlots.Include(c => c.Contract).Include(c => c.Plot);
            return View(await agroContext.ToListAsync());
        }

        // GET: ContractPlots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContractPlots == null)
            {
                return NotFound();
            }

            var contractPlot = await _context.ContractPlots
                .Include(c => c.Contract)
                .Include(c => c.Plot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractPlot == null)
            {
                return NotFound();
            }

            return View(contractPlot);
        }

        // GET: ContractPlots/Create
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id");
            ViewData["PlotId"] = new SelectList(_context.Plots, "Id", "Id");
            return View();
        }

        // POST: ContractPlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractId,PlotId")] ContractPlot contractPlot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractPlot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", contractPlot.ContractId);
            ViewData["PlotId"] = new SelectList(_context.Plots, "Id", "Id", contractPlot.PlotId);
            return View(contractPlot);
        }

        // GET: ContractPlots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContractPlots == null)
            {
                return NotFound();
            }

            var contractPlot = await _context.ContractPlots.FindAsync(id);
            if (contractPlot == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", contractPlot.ContractId);
            ViewData["PlotId"] = new SelectList(_context.Plots, "Id", "Id", contractPlot.PlotId);
            return View(contractPlot);
        }

        // POST: ContractPlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractId,PlotId")] ContractPlot contractPlot)
        {
            if (id != contractPlot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractPlot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractPlotExists(contractPlot.Id))
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
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", contractPlot.ContractId);
            ViewData["PlotId"] = new SelectList(_context.Plots, "Id", "Id", contractPlot.PlotId);
            return View(contractPlot);
        }

        // GET: ContractPlots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContractPlots == null)
            {
                return NotFound();
            }

            var contractPlot = await _context.ContractPlots
                .Include(c => c.Contract)
                .Include(c => c.Plot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractPlot == null)
            {
                return NotFound();
            }

            return View(contractPlot);
        }

        // POST: ContractPlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContractPlots == null)
            {
                return Problem("Entity set 'AgroContext.ContractPlots'  is null.");
            }
            var contractPlot = await _context.ContractPlots.FindAsync(id);
            if (contractPlot != null)
            {
                _context.ContractPlots.Remove(contractPlot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractPlotExists(int id)
        {
          return (_context.ContractPlots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
