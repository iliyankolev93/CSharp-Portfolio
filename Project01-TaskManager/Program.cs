using System;

namespace Project01_TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== TASK MANAGER ===");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Delete task");
                Console.WriteLine("3. View tasks");
                Console.WriteLine("4. Complete task");
                Console.WriteLine("5. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)

                {
                    case "1":
                        manager.AddTask();
                        break;

                    case "2":
                        manager.DeleteTask();
                        break;

                    case "3":
                        manager.ViewTasks();
                        break;

                    case "4":
                        manager.CompleteTask();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("\nPress Enter...");
                Console.ReadLine();
            }
        }
    }
}