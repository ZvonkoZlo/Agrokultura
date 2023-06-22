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
    public class PlantPassportsController : Controller
    {
        private readonly AgroContext _context;

        public PlantPassportsController(AgroContext context)
        {
            _context = context;
        }

        // GET: PlantPassports
        public async Task<IActionResult> Index()
        {
            var plantPassports = await _context.PlantPassports.ToListAsync();
            return View(plantPassports);
        }

        // GET: PlantPassports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantPassport = await _context.PlantPassports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantPassport == null)
            {
                return NotFound();
            }

            return View(plantPassport);
        }

        // GET: PlantPassports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlantPassports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountryOfOrigin,DateOfIssue,IssuingAuthority,CertificateNumber,Description")] PlantPassport plantPassport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantPassport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantPassport);
        }

        // GET: PlantPassports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantPassport = await _context.PlantPassports.FindAsync(id);
            if (plantPassport == null)
            {
                return NotFound();
            }
            return View(plantPassport);
        }

        // POST: PlantPassports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountryOfOrigin,DateOfIssue,IssuingAuthority,CertificateNumber,Description")] PlantPassport plantPassport)
        {
            if (id != plantPassport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantPassport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantPassportExists(plantPassport.Id))
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
            return View(plantPassport);
        }

        // GET: PlantPassports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantPassport = await _context.PlantPassports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantPassport == null)
            {
                return NotFound();
            }

            return View(plantPassport);
        }

        // POST: PlantPassports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantPassport = await _context.PlantPassports.FindAsync(id);
            _context.PlantPassports.Remove(plantPassport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantPassportExists(int id)
        {
            return _context.PlantPassports.Any(e => e.Id == id);
        }
    }
}
