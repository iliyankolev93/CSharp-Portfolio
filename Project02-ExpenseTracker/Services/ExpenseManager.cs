using System;
using System.Collections.Generic;
using System.Linq;
using Project02_ExpenseTracker.Models;
using Project02_ExpenseTracker.Data;

namespace Project02_ExpenseTracker.Services
{
    public class ExpenseManager
    {
        private List<Expense> expenses;
        private ExpenseRepository repository;

        public ExpenseManager()
        {
            repository = new ExpenseRepository();
            expenses = repository.Load();
        }

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
            repository.Save(expenses);
        }

        public List<Expense> GetAll()
        {
            return expenses;
        }

        public decimal GetTotal()
        {
            return expenses.Sum(e => e.Amount);
        }

        public List<Expense> GetByCategory(string category)
        {
            return expenses
                .Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool Delete(int index)
        {
            if (index < 0 || index >= expenses.Count)
                return false;

            expenses.RemoveAt(index);
            repository.Save(expenses);

            return true;
        }
    }
}