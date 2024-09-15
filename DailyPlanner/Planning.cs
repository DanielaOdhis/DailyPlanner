using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPlanner
{
    public class Planning
    {
        private List<Tasks> tasks = new List<Tasks>();
        private const string FILE_NAME = "tasks.txt";
        public Planning() 
        {
            LoadTasks();
        }

        public void AddTask(string taskName, string taskDescription, DateTime taskDueDate)
        {
            tasks.Add(new Tasks(taskName, taskDescription, taskDueDate));
            SaveTasks();
        }

        public void RemoveTask(string taskName)
        {
            tasks.RemoveAll(t => t.TaskName == taskName);
            SaveTasks();
        }

        public void CompleteTask(int taskIndex)
        {
            if (taskIndex >= 0 && taskIndex < tasks.Count)
            {
                tasks[taskIndex].CompleteTask();
                SaveTasks();
            }
            else
            {
                Console.WriteLine("Invalid task index");
            }
        }

        public void PrintTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to display");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"Task {i + 1}");
                    tasks[i].PrintTask();
                }
            }
        }

        private void LoadTasks()
        {
            // Load tasks from a file
            if (System.IO.File.Exists(FILE_NAME))
            {
                string[] lines = System.IO.File.ReadAllLines(FILE_NAME);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string taskName = parts[0];
                    string taskDescription = parts[1];
                    DateTime taskDueDate = DateTime.Parse(parts[2]);
                    bool taskCompleted = bool.Parse(parts[3]);
                    Tasks task = new Tasks(taskName, taskDescription, taskDueDate);
                    if (taskCompleted)
                    {
                        task.CompleteTask();
                    }
                    tasks.Add(task);
                }
            }
        }

        private void SaveTasks()
        {
            // Save tasks to a file
            List<string> lines = new List<string>();
            foreach (Tasks task in tasks)
            {
                string line = $"{task.TaskName},{task.TaskDescription},{task.TaskDueDate},{task.TaskCompleted}";
                lines.Add(line);
            }
            System.IO.File.WriteAllLines(FILE_NAME, lines);
        }
    }
}
