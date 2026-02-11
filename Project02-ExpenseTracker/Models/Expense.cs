using System;

namespace Project02_ExpenseTracker.Models
{
    public class Expense
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public Expense()
        {
            Date = DateTime.Now;
            IsCompleted = false;
        }
    }
}