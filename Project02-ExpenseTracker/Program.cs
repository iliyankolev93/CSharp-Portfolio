using System;
using Project02_ExpenseTracker.Models;
using Project02_ExpenseTracker.Services;

namespace Project02_ExpenseTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExpenseManager manager = new ExpenseManager();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== EXPENSE TRACKER ===");
                Console.WriteLine("1. Add expense");
                Console.WriteLine("2. View all expenses");
                Console.WriteLine("3. Filter by category");
                Console.WriteLine("4. Show total spent");
                Console.WriteLine("5. Delete expense");
                Console.WriteLine("6. Exit");

                Console.Write("\nChoose option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddExpense(manager);
                }

                else if (choice == "2")
                {
                    ViewAll(manager);
                }

                else if (choice == "3")
                {
                    Filter(manager);
                }

                else if (choice == "4")
                {
                    ShowTotal(manager);
                }

                else if (choice == "5")
                {
                    Delete(manager);
                }

                else if (choice == "6")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid option.");
                    Pause();
                }
            }
        }

        static void AddExpense(ExpenseManager manager)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Expense expense = new Expense
            {
                Name = name,
                Amount = amount,
                Category = category
            };

            manager.AddExpense(expense);

            Console.WriteLine("Expense added.");
            Pause();
        }

        static void ViewAll(ExpenseManager manager)
        {
            var expenses = manager.GetAll();

            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses.");
            }

            else
            {
                for (int i = 0; i < expenses.Count; i++)
                {
                    var e = expenses[i];

                    Console.WriteLine(
                        $"{i + 1}. {e.Name} | {e.Amount:F2} | {e.Category} | {e.Date:d}"
                    );
                }
            }

            Pause();
        }

        static void Filter(ExpenseManager manager)
        {
            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            var result = manager.GetByCategory(category);

            if (result.Count == 0)
            {
                Console.WriteLine("No results.");
            }

            else
            {
                foreach (var e in result)
                {
                    Console.WriteLine(
                        $"{e.Name} | {e.Amount:F2} | {e.Category} | {e.Date:d}"
                    );
                }
            }

            Pause();
        }

        static void ShowTotal(ExpenseManager manager)
        {
            decimal total = manager.GetTotal();

            Console.WriteLine($"Total spent: {total:F2}");
            Pause();
        }

        static void Delete(ExpenseManager manager)
        {
            ViewAll(manager);

            Console.Write("Enter number to delete: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (manager.Delete(number - 1))
                {
                    Console.WriteLine("Deleted.");
                }

                else
                {
                    Console.WriteLine("Invalid number.");
                }
            }

            else
            {
                Console.WriteLine("Invalid input.");
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}