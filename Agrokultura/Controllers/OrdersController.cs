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
    public class OrdersController : Controller
    {
        private readonly AgroContext _context;

        public OrdersController(AgroContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var agroContext = _context.Orders.Include(o => o.Customer).Include(o => o.OrderStatus).Include(o => o.Plant);
            return View(await agroContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderStatus)
                .Include(o => o.Plant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.People, "Id", "Id");
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id");
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AmountOfGoods,CustomerId,PlantId,OrderStatusId")] Order order)
        {
            ViewData["CustomerId"] = new SelectList(_context.People, "Id", "Id", order.CustomerId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id", order.OrderStatusId);
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Id", order.PlantId);
            _context.Add(order);
            _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
         
           
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.People, "Id", "Id", order.CustomerId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id", order.OrderStatusId);
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Id", order.PlantId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AmountOfGoods,CustomerId,PlantId,OrderStatusId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.People, "Id", "Id", order.CustomerId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id", order.OrderStatusId);
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Id", order.PlantId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderStatus)
                .Include(o => o.Plant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'AgroContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
