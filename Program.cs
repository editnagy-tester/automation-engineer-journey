// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManager;

var taskService = new TaskService();
string path = "tasks.json";

taskService.LoadFromFile(path);


bool running = true;


while (running)
{
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. List Tasks");
    Console.WriteLine("3. Remove Task");
    Console.WriteLine("4. Exit");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("Enter Task Title to add:");

            var result = taskService.AddTask(Console.ReadLine());

            switch (result)
            {
                case AddTaskResult.Success:
                    Console.WriteLine("Task added succesfully!");
                    break;
                case AddTaskResult.EmptyTitle:
                    Console.WriteLine("Please type a valid title!");
                    break;
                case AddTaskResult.DuplicateTitle:
                    Console.WriteLine("Task already exists with this title!");
                    break;
                default:
                    break;
            }

            break;
        case "2":
            var tasks = taskService.GetAllTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Completed: {task.IsCompleted}");
            }
            break;
        case "3":
            Console.WriteLine("Enter Task ID to remove:");
            if (int.TryParse(Console.ReadLine(), out int idnumber))
            {
                bool removed = taskService.RemoveTask(idnumber);
                if (removed)
                    Console.WriteLine("Task removed successfully!");
                else
                    Console.WriteLine("Task not found!");

            }
            else
            {
                Console.WriteLine("Invalid ID format");
            }

            break;
        case "4":
            taskService.SaveToFile(path);
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}
