using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class TaskService
    {
        private List<TaskItem> tasks;

        public TaskService()
        { 
            tasks = new List<TaskItem>();
        }

        public void AddTask(string title)
        {
            int id = tasks.Count + 1;
            TaskItem newTask = new TaskItem(id, title);
            tasks.Add(newTask);
        }

        public void RemoveTask(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
        }

        public List<TaskItem> GetAllTasks()
        {
            return tasks;
        }

    }
}
