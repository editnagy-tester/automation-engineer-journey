using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

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
        private int _nextId = 1;

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

            TaskItem newTask = new TaskItem(_nextId++, title);
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

        public void SaveToFile(string path)
        {
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(path, json); //oberwrites existing file, or create a new one
        }

        public void LoadFromFile(string path) 
        {
            if (File.Exists(path))
            {
                string taskstext = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(taskstext)) //for empty file
                {
                    _nextId = 1;
                    return;
                }
                List<TaskItem> deserializedTasks;
                try
                {
                    deserializedTasks = JsonSerializer.Deserialize<List<TaskItem>>(taskstext);
                    if (deserializedTasks != null)
                    {
                        tasks = deserializedTasks;
                        if (tasks.Count > 0) //in case json file has empty list []
                        {
                            _nextId = tasks.Max(t => t.Id) + 1;
                        }
                        else
                        {
                            _nextId = 1;
                        }
                    }
                    else
                    {
                        _nextId = 1;
                    }
                }
                catch (Exception)
                {
                    _nextId = 1;
                }
                
                
            }

        }

    }
}
