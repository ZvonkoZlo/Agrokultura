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
    public class ChorePersonsController : Controller
    {
        private readonly AgroContext _context;

        public ChorePersonsController(AgroContext context)
        {
            _context = context;
        }

        // GET: ChorePersons
        public async Task<IActionResult> Index()
        {
            var agroContext = _context.ChorePeople.Include(c => c.Chore).Include(c => c.OrderStatus).Include(c => c.Person);
            return View(await agroContext.ToListAsync());
        }

        // GET: ChorePersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChorePeople == null)
            {
                return NotFound();
            }

            var chorePerson = await _context.ChorePeople
                .Include(c => c.Chore)
                .Include(c => c.OrderStatus)
                .Include(c => c.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chorePerson == null)
            {
                return NotFound();
            }

            return View(chorePerson);
        }

        // GET: ChorePersons/Create
        public IActionResult Create()
        {
            ViewData["ChoreId"] = new SelectList(_context.Chores, "Id", "Id");
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id");
            return View();
        }

        // POST: ChorePersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,OrderStatusId,ChoreId,PersonId")] ChorePerson chorePerson)
        {
            ViewData["ChoreId"] = new SelectList(_context.Chores, "Id", "Id", chorePerson.ChoreId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id", chorePerson.OrderStatusId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", chorePerson.PersonId);
         
                _context.Add(chorePerson);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: ChorePersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChorePeople == null)
            {
                return NotFound();
            }

            var chorePerson = await _context.ChorePeople.FindAsync(id);
            if (chorePerson == null)
            {
                return NotFound();
            }
            ViewData["ChoreId"] = new SelectList(_context.Chores, "Id", "Id", chorePerson.ChoreId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id", chorePerson.OrderStatusId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", chorePerson.PersonId);
            return View(chorePerson);
        }

        // POST: ChorePersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,OrderStatusId,ChoreId,PersonId")] ChorePerson chorePerson)
        {
            if (id != chorePerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chorePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChorePersonExists(chorePerson.Id))
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
            ViewData["ChoreId"] = new SelectList(_context.Chores, "Id", "Id", chorePerson.ChoreId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id", chorePerson.OrderStatusId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", chorePerson.PersonId);
            return View(chorePerson);
        }

        // GET: ChorePersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChorePeople == null)
            {
                return NotFound();
            }

            var chorePerson = await _context.ChorePeople
                .Include(c => c.Chore)
                .Include(c => c.OrderStatus)
                .Include(c => c.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chorePerson == null)
            {
                return NotFound();
            }

            return View(chorePerson);
        }

        // POST: ChorePersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChorePeople == null)
            {
                return Problem("Entity set 'AgroContext.ChorePeople'  is null.");
            }
            var chorePerson = await _context.ChorePeople.FindAsync(id);
            if (chorePerson != null)
            {
                _context.ChorePeople.Remove(chorePerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChorePersonExists(int id)
        {
          return (_context.ChorePeople?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
