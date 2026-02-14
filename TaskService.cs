using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public enum AddTaskResult
    {
        Success,
        EmptyTitle,
        DuplicateTitle
    }
    internal class TaskService
    {
        
        private List<TaskItem> tasks;

        public TaskService()
        { 
            tasks = new List<TaskItem>();
        }

        public AddTaskResult AddTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return AddTaskResult.EmptyTitle;
            }
            if (tasks.Any(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase))) // case insensitive
            {
                return AddTaskResult.DuplicateTitle;
            }

            int id = tasks.Count + 1;
            TaskItem newTask = new TaskItem(id, title);
            tasks.Add(newTask);
            return AddTaskResult.Success;
        }

        public bool RemoveTask(int id)
        {
            TaskItem? task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) 
            {
                return false;
            }
            tasks.Remove(task);
            return true;
        }

        public List<TaskItem> GetAllTasks()
        {
            return tasks;
        }

    }
}
