using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPlanner
{
    public class Program
    {
        static void Main(string[] args)
        {
            Planning planning = new Planning();
            string command = "";
            while (command != "exit")
            {
                Console.WriteLine("Enter a command: add, remove, complete, print, exit");
                command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                        Console.WriteLine("Enter task name:");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Enter task description:");
                        string taskDescription = Console.ReadLine();

                        DateTime taskDueDate;
                        Console.WriteLine("Enter task due date (e.g., MM/dd/yyyy or yyyy-MM-dd):");
                        string dueDateInput = Console.ReadLine();

                        if (DateTime.TryParse(dueDateInput, out taskDueDate))
                        {
                            planning.AddTask(taskName, taskDescription, taskDueDate);
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Please enter a valid date.");
                        }
                        break;

                    case "remove":
                        Console.WriteLine("Enter task name:");
                        string taskNameToRemove = Console.ReadLine();
                        planning.RemoveTask(taskNameToRemove);
                        break;
                    case "complete":
                        Console.WriteLine("Enter task index:");
                        int taskIndex = int.Parse(Console.ReadLine());
                        planning.CompleteTask(taskIndex);
                        break;
                    case "print":
                        planning.PrintTasks();
                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}
