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
            var contractPlots = await _context.ContractPlots
                .Include(cp => cp.Contract)
                .Include(cp => cp.Plot)
                .ToListAsync();

            return View(contractPlots);
        }

        // GET: ContractPlots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractPlot = await _context.ContractPlots
                .Include(cp => cp.Contract)
                .Include(cp => cp.Plot)
                .FirstOrDefaultAsync(cp => cp.Id == id);

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractId,PlotId,MonthlyPayment,Price")] ContractPlot contractPlot)
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

            // Populate the ViewBag.Contracts with the list of contracts
            ViewBag.Contracts = new SelectList(_context.Contracts, "Id", "Name", contractPlot.ContractId);

            // Populate the ViewBag.Plots with the list of plots
            ViewBag.Plots = new SelectList(_context.Plots, "Id", "Name", contractPlot.PlotId);

            return View(contractPlot);
        }

        // POST: ContractPlots/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractId,PlotId,MonthlyPayment,Price")] ContractPlot contractPlot)
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
            if (id == null)
            {
                return NotFound();
            }

            var contractPlot = await _context.ContractPlots
                .Include(cp => cp.Contract)
                .Include(cp => cp.Plot)
                .FirstOrDefaultAsync(cp => cp.Id == id);

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
            var contractPlot = await _context.ContractPlots.FindAsync(id);
            if (contractPlot == null)
            {
                return NotFound();
            }

            _context.ContractPlots.Remove(contractPlot);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ContractPlotExists(int id)
        {
            return _context.ContractPlots.Any(cp => cp.Id == id);
        }
    }
}
