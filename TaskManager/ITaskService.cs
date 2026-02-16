using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal interface ITaskService
    {
        AddTaskResult AddTask(string title);
        bool RemoveTask(int id);
        List<TaskItem> GetAllTasks();
        void SaveToFile(string path);
        void LoadFromFile(string path);
    }
}
