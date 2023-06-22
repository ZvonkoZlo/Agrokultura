using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agrokultura.Models;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace Agrokultura.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AgroContext _context;

        public OrdersController(AgroContext context)
        {
            _context = context;
        }
        public ActionResult GenerirajPDF()
        {
            Document pdfDokument = new Document();
            Page stranica = pdfDokument.Pages.Add();

            TextFragment text1 = new TextFragment("Agrokultura Narudzbe");
            text1.Position = new Position(160, 750);
            text1.TextState.FontSize = 25;
            stranica.Paragraphs.Add(text1);

            Table table = new Table();
            table.ColumnWidths = "100 100 100 100";
            table.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.1f);
            table.DefaultCellTextState.LineSpacing = 7;

            Row headerRow = table.Rows.Add();
            headerRow.Cells.Add("Biljka");
            headerRow.Cells.Add("Količina dobara");
            headerRow.Cells.Add("Naručitelj");
            headerRow.Cells.Add("Status narudzbe");

            var narudzbe = _context.Orders
         .Include(o => o.Plant)
         .Include(o => o.Customer)
         .Include(o => o.OrderStatus)
         .ToList();

            foreach (var narudzba in narudzbe)
            {
                Row row = table.Rows.Add();
                row.Cells.Add(narudzba.Plant.Name);
                row.Cells.Add(narudzba.AmountOfGoods.ToString());
                row.Cells.Add(narudzba.Customer.FullName);
                row.Cells.Add(narudzba.OrderStatus.Name);
            }

            TextFragment text2 = new TextFragment("");
            text2.Position = new Position(160, 700);
            text2.TextState.FontSize = 15;

            stranica.Paragraphs.Add(text2);
            stranica.Paragraphs.Add(table);

            // Spremite PDF dokument na željenu lokaciju
           // string putanja = "C:\\Users\\Zvonko\\source\\repos\\AsposePdfTestiranje\\AsposePdfTestiranje\\";
           // putanja = putanja + "novi_dokument3.pdf";
            
           

            // Spremite PDF dokument u MemoryStream
            MemoryStream memoryStream = new MemoryStream();
            pdfDokument.Save(memoryStream);
            memoryStream.Position = 0;
            pdfDokument.Dispose();
            // Vratite PDF dokument kao preuzimanje
            return File(memoryStream, "application/pdf", "PrintOrders.pdf");
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
            ViewData["CustomerId"] = new SelectList(_context.People, "Id", "FullName");
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Name");
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AmountOfGoods,CustomerId,PlantId,OrderStatusId")] Order order)
        {
            ViewData["CustomerId"] = new SelectList(_context.People, "Id", "FullName", order.CustomerId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Name", order.OrderStatusId);
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Name", order.PlantId);
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
            ViewData["CustomerId"] = new SelectList(_context.People, "Id", "FullName", order.CustomerId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Name", order.OrderStatusId);
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Name", order.PlantId);
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
            ViewData["CustomerId"] = new SelectList(_context.People, "Id", "FullName", order.CustomerId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Name", order.OrderStatusId);
            ViewData["PlantId"] = new SelectList(_context.Plants, "Id", "Name", order.PlantId);
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
