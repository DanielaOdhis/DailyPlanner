using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPlanner
{
    public class Tasks
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDueDate { get; set; }
        public bool TaskCompleted { get; set; }

        public Tasks(string taskName, string taskDescription, DateTime taskDueDate)
        {
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskDueDate = taskDueDate;
            TaskCompleted = false;
        }

        public void CompleteTask()
        {
            TaskCompleted = true;
        }

        public void PrintTask()
        {
            Console.WriteLine($"Task Name: {TaskName}");
            Console.WriteLine($"Task Description: {TaskDescription}");
            Console.WriteLine($"Task Due Date: {TaskDueDate}");
            Console.WriteLine($"Task Completed: {TaskCompleted}");
        }
    }
}
