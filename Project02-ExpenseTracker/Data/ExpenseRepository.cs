using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Project02_ExpenseTracker.Models;

namespace Project02_ExpenseTracker.Data
{
    public class ExpenseRepository
    {
        private const string FileName = "expenses.json";

        public void Save(List<Expense> expenses)
        {
            string json = JsonSerializer.Serialize(expenses, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FileName, json);
        }

        public List<Expense> Load()
        {
            if (!File.Exists(FileName))
            {
                return new List<Expense>();
            }

            string json = File.ReadAllText(FileName);

            List<Expense> expenses = JsonSerializer.Deserialize<List<Expense>>(json);

            return expenses ?? new List<Expense>();
        }
    }
}