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
    public class GoodsTypesController : Controller
    {
        private readonly AgroContext _context;

        public GoodsTypesController(AgroContext context)
        {
            _context = context;
        }

        // GET: GoodsTypes
        public async Task<IActionResult> Index()
        {
              return _context.GoodsTypes != null ? 
                          View(await _context.GoodsTypes.ToListAsync()) :
                          Problem("Entity set 'AgroContext.GoodsTypes'  is null.");
        }

        // GET: GoodsTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GoodsTypes == null)
            {
                return NotFound();
            }

            var goodsType = await _context.GoodsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsType == null)
            {
                return NotFound();
            }

            return View(goodsType);
        }

        // GET: GoodsTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodsTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GoodsType goodsType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodsType);
        }

        // GET: GoodsTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GoodsTypes == null)
            {
                return NotFound();
            }

            var goodsType = await _context.GoodsTypes.FindAsync(id);
            if (goodsType == null)
            {
                return NotFound();
            }
            return View(goodsType);
        }

        // POST: GoodsTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GoodsType goodsType)
        {
            if (id != goodsType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsTypeExists(goodsType.Id))
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
            return View(goodsType);
        }

        // GET: GoodsTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GoodsTypes == null)
            {
                return NotFound();
            }

            var goodsType = await _context.GoodsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsType == null)
            {
                return NotFound();
            }

            return View(goodsType);
        }

        // POST: GoodsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoodsTypes == null)
            {
                return Problem("Entity set 'AgroContext.GoodsTypes'  is null.");
            }
            var goodsType = await _context.GoodsTypes.FindAsync(id);
            if (goodsType != null)
            {
                _context.GoodsTypes.Remove(goodsType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsTypeExists(int id)
        {
          return (_context.GoodsTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
