using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = false;



        public TaskItem(int id, string title)
        {
            Id = id;
            Title= title;
        }
    }
}
