using Microsoft.AspNetCore.Mvc;
using Project03_ExpenseWebApp.Data;
using Project03_ExpenseWebApp.Models;

namespace Project03_ExpenseWebApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly AppDbContext _context;

        public ExpensesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var expenses = _context.Expenses.ToList();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(expense);
        }

        public IActionResult Edit(int id)
        {
            var expense = _context.Expenses.Find(id);

            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        [HttpPost]
        public IActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expense);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(expense);
        }

        public IActionResult Delete(int id)
        {
            var expense = _context.Expenses.Find(id);

            if (expense == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expense);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}