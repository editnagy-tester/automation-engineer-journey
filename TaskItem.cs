using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    internal class TaskItem
    {
        int Id { get; set; }
        string Title { get; set; }
        bool IsCompleted { get; set; } = false;



        public TaskItem(int id, string title)
        {
            Id = id;
            Title= title;
        }
    }
}
