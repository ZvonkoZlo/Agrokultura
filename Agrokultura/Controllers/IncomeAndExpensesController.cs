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
    public class IncomeAndExpensesController : Controller
    {
        private readonly AgroContext _context;

        public IncomeAndExpensesController(AgroContext context)
        {
            _context = context;
        }

        // GET: IncomeAndExpenses
        public async Task<IActionResult> Index()
        {
            var agroContext = _context.IncomeAndExpenses.Include(i => i.Plant).Include(i => i.Plot);
            return View(await agroContext.ToListAsync());
        }

        // GET: IncomeAndExpenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IncomeAndExpenses == null)
            {
                return NotFound();
            }

            var incomeAndExpense = await _context.IncomeAndExpenses
                .Include(i => i.Plant)
                .Include(i => i.Plot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeAndExpense == null)
            {
                return NotFound();
            }

            return View(incomeAndExpense);
        }

        // GET: IncomeAndExpenses/Create
        public IActionResult Create()
        {
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Id");
            ViewData["PlotId"] = new SelectList(_context.Plots, "Id", "Id");
            return View();
        }

        // POST: IncomeAndExpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlotId,PlantId,AmountOfPlants,Price,DateOfPlanting,EndDateOfPlanting,AmountOfGoods")] IncomeAndExpense incomeAndExpense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomeAndExpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Id", incomeAndExpense.PlantId);
            ViewData["PlotId"] = new SelectList(_context.Plots, "Id", "Id", incomeAndExpense.PlotId);
            return View(incomeAndExpense);
        }

        // GET: IncomeAndExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IncomeAndExpenses == null)
            {
                return NotFound();
            }

            var incomeAndExpense = await _context.IncomeAndExpenses.FindAsync(id);
            if (incomeAndExpense == null)
            {
                return NotFound();
            }
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Id", incomeAndExpense.PlantId);
            ViewData["PlotId"] = new SelectList(_context.Plots, "Id", "Id", incomeAndExpense.PlotId);
            return View(incomeAndExpense);
        }

        // POST: IncomeAndExpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlotId,PlantId,AmountOfPlants,Price,DateOfPlanting,EndDateOfPlanting,AmountOfGoods")] IncomeAndExpense incomeAndExpense)
        {
            if (id != incomeAndExpense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeAndExpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeAndExpenseExists(incomeAndExpense.Id))
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
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Id", incomeAndExpense.PlantId);
            ViewData["PlotId"] = new SelectList(_context.Plots, "Id", "Id", incomeAndExpense.PlotId);
            return View(incomeAndExpense);
        }

        // GET: IncomeAndExpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IncomeAndExpenses == null)
            {
                return NotFound();
            }

            var incomeAndExpense = await _context.IncomeAndExpenses
                .Include(i => i.Plant)
                .Include(i => i.Plot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeAndExpense == null)
            {
                return NotFound();
            }

            return View(incomeAndExpense);
        }

        // POST: IncomeAndExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IncomeAndExpenses == null)
            {
                return Problem("Entity set 'AgroContext.IncomeAndExpenses'  is null.");
            }
            var incomeAndExpense = await _context.IncomeAndExpenses.FindAsync(id);
            if (incomeAndExpense != null)
            {
                _context.IncomeAndExpenses.Remove(incomeAndExpense);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeAndExpenseExists(int id)
        {
          return (_context.IncomeAndExpenses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
