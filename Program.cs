// See https://aka.ms/new-console-template for more information
using TaskManager;

var taskService = new TaskService();
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
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                taskService.AddTask(title);
            }
            else
            {
                Console.WriteLine("Invalid Title");
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
            string id = Console.ReadLine();
            if (int.TryParse(id, out int idnumber))
            {
                taskService.RemoveTask(idnumber);
            }
            else
            {
                Console.WriteLine("Invalid ID format");
            }

            break;
        case "4":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}
