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
    public class PlantsController : Controller
    {
        private readonly AgroContext _context;

        public PlantsController(AgroContext context)
        {
            _context = context;
        }

        // GET: Plants
        public async Task<IActionResult> Index()
        {
            var agroContext = _context.Plants.Include(p => p.GoodsType).Include(p => p.Manufacturer).Include(p => p.PlantType);
            return View(await agroContext.ToListAsync());
        }

        // GET: Plants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants
                .Include(p => p.GoodsType)
                .Include(p => p.Manufacturer)
                .Include(p => p.PlantType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // GET: Plants/Create
        public IActionResult Create()
        {
            ViewData["GoodsTypeId"] = new SelectList(_context.GoodsTypes, "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.People, "Id", "FullName");
            ViewData["PlantTypeId"] = new SelectList(_context.PlantTypes, "Id", "Name");
            return View();
        }

        // POST: Plants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,SubspeciesName,AmountOfGoods,Price,PlantTypeId,GoodsTypeId,ManufacturerId,Color")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GoodsTypeId"] = new SelectList(_context.GoodsTypes, "Id", "Name", plant.GoodsTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.People, "Id", "FullName", plant.ManufacturerId);
            ViewData["PlantTypeId"] = new SelectList(_context.PlantTypes, "Id", "Name", plant.PlantTypeId);
            return View(plant);
        }

        // GET: Plants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            ViewData["GoodsTypeId"] = new SelectList(_context.GoodsTypes, "Id", "Name", plant.GoodsTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.People, "Id", "FullName", plant.ManufacturerId);
            ViewData["PlantTypeId"] = new SelectList(_context.PlantTypes, "Id", "Name", plant.PlantTypeId);
            return View(plant);
        }

        // POST: Plants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,SubspeciesName,AmountOfGoods,Price,PlantTypeId,GoodsTypeId,ManufacturerId,Color")] Plant plant)
        {
            if (id != plant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantExists(plant.Id))
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
            ViewData["GoodsTypeId"] = new SelectList(_context.GoodsTypes, "Id", "Name", plant.GoodsTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.People, "Id", "FullName", plant.ManufacturerId);
            ViewData["PlantTypeId"] = new SelectList(_context.PlantTypes, "Id", "Name", plant.PlantTypeId);
            return View(plant);
        }

        // GET: Plants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants
                .Include(p => p.GoodsType)
                .Include(p => p.Manufacturer)
                .Include(p => p.PlantType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plants == null)
            {
                return Problem("Entity set 'AgroContext.Plants'  is null.");
            }
            var plant = await _context.Plants.FindAsync(id);
            if (plant != null)
            {
                _context.Plants.Remove(plant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantExists(int id)
        {
          return (_context.Plants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
