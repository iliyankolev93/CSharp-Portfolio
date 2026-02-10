using System;
using System.Collections.Generic;
using System.IO;

namespace Project01_TaskManager
{
    public class TaskManager
    {
        private List<TodoTask> tasks;
        private string filePath = "tasks.txt";

        public TaskManager()
        {
            tasks = LoadTasks();
        }

        public void AddTask()
        {
            Console.Write("Enter new task: ");
            string title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Task cannot be empty.");
                return;
            }

            tasks.Add(new TodoTask
            {
                Title = title,
                IsCompleted = false
            });

            SaveTasks();
            Console.WriteLine("Task added.");
        }

        public void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet.");
                return;
            }

            Console.WriteLine("Tasks list:");

            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].IsCompleted ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {status} {tasks[i].Title}");
            }
        }

        public void DeleteTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to delete.");
                return;
            }

            ViewTasks();

            Console.Write("Enter number to delete: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number)
                && number >= 1 && number <= tasks.Count)
            {
                tasks.RemoveAt(number - 1);
                SaveTasks();
                Console.WriteLine("Task deleted.");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }

        public void CompleteTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks.");
                return;
            }

            ViewTasks();

            Console.Write("Enter number to complete: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number)
                && number >= 1 && number <= tasks.Count)
            {
                tasks[number - 1].IsCompleted = true;
                SaveTasks();
                Console.WriteLine("Completed.");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }

        // ================= FILE =================

        private void SaveTasks()
        {
            List<string> lines = new List<string>();

            foreach (var task in tasks)
            {
                lines.Add($"{task.IsCompleted}|{task.Title}");
            }

            File.WriteAllLines(filePath, lines);
        }

        private List<TodoTask> LoadTasks()
        {
            List<TodoTask> list = new List<TodoTask>();

            if (!File.Exists(filePath))
                return list;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts.Length == 2)
                {
                    list.Add(new TodoTask
                    {
                        IsCompleted = bool.Parse(parts[0]),
                        Title = parts[1]
                    });
                }
            }

            return list;
        }
    }
}