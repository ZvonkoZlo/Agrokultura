using Agrokultura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Agrokultura.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgroContext _context;

        
        public HomeController(AgroContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int brojNarudzbi = _context.Orders.Count()-2;
            ViewBag.Order = brojNarudzbi;
            int numberOfPeople = _context.People.Count();
            ViewBag.People = numberOfPeople;
            var agroContext = _context.Orders.Include(o => o.Customer).Include(o => o.OrderStatus).Include(o => o.Plant);
            var ChoreContext = _context.ChorePeople.Include(c => c.Chore).Include(c => c.OrderStatus).Include(c => c.Person);

            var orders = agroContext.ToList();
    var chores = ChoreContext.ToList();

            double totalIncome = _context.IncomeAndExpenses
                          .Where(ie => ie.Price > 0)
                          .Sum(ie => ie.Price ?? 0);

            double totalExpense = Math.Abs(_context.IncomeAndExpenses
                .Where(ie => ie.Price < 0)
                .Sum(ie => ie.Price ?? 0));

            ViewBag.TotalIncome = totalIncome;
            ViewBag.TotalExpense = totalExpense;

            var combinedViewModel = new CombinedViewModel
    {
        Orders = orders,
        Chores = chores
    };


            var parcels = _context.Plots.ToList();
            var incomeAndExpenses = _context.IncomeAndExpenses.ToList();

            var tableData = parcels.Select(parcel => new
            {
                ParcelName = parcel.Name,
                TotalIncome = incomeAndExpenses
                    .Where(ie => ie.PlotId == parcel.Id && ie.Price > 0)
                    .Sum(ie => ie.Price ?? 0),
                TotalExpense = Math.Abs(incomeAndExpenses
                    .Where(ie => ie.PlotId == parcel.Id && ie.Price < 0)
                    .Sum(ie => ie.Price ?? 0)),
                TotalBalance = incomeAndExpenses
                 .Where(ie => ie.PlotId == parcel.Id)
                     .Sum(ie => ie.Price ?? 0)
            }).ToList();

            ViewBag.TableData = tableData;

            return View(combinedViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}