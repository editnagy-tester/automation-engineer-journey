// See https://aka.ms/new-console-template for more information
using TaskManager;

Console.WriteLine("Hello, this is my learning journey!");
TaskService taskService = new TaskService();
taskService.AddTask("Learn C#");
taskService.AddTask("Build a project");
taskService.AddTask("Small task");
taskService.GetAllTasks();
taskService.RemoveTask(2);
taskService.GetAllTasks();