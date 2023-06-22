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
    public class ContractsController : Controller
    {
        private readonly AgroContext _context;

        public ContractsController(AgroContext context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            var agroContext = _context.Contracts.Include(c => c.Beneficiary).Include(c => c.Provider);
            return View(await agroContext.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Beneficiary)
                .Include(c => c.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["BeneficiaryId"] = new SelectList(_context.People, "Id", "FullName");
            ViewData["ProviderId"] = new SelectList(_context.People, "Id", "FullName");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProviderId,BeneficiaryId,DateOfConclusion,DateOfExpiration,ContractType")] Contract contract)
        {
            ViewData["BeneficiaryId"] = new SelectList(_context.People, "Id", "FullName", contract.BeneficiaryId);
            ViewData["ProviderId"] = new SelectList(_context.People, "Id", "FullName", contract.ProviderId);


            _context.Add(contract);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewBag.BeneficiaryId = new SelectList(_context.People, "Id", "FullName", contract.BeneficiaryId);
if (contract.ProviderId != null)
{
    ViewBag.ProviderId = new SelectList(_context.People, "Id", "FullName", contract.ProviderId);
}

            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProviderId,BeneficiaryId,DateOfConclusion,DateOfExpiration,ContractType")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }


            _context.Update(contract);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Beneficiary)
                .Include(c => c.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contracts == null)
            {
                return Problem("Entity set 'AgroContext.Contracts'  is null.");
            }
            var contract = await _context.Contracts.FindAsync(id);
            if (contract != null)
            {
                _context.Contracts.Remove(contract);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return (_context.Contracts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}