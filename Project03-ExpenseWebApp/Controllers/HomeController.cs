using Microsoft.AspNetCore.Mvc;
using Project03_ExpenseWebApp.Data;
using System.Linq;

namespace Project03_ExpenseWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var total = _context.Expenses.Sum(e => e.Amount);

            var latest = _context.Expenses
                                 .OrderByDescending(e => e.Date)
                                 .Take(5)
                                 .ToList();

            ViewBag.Total = total;
            ViewBag.Latest = latest;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}