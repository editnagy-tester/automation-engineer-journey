using TaskManager;
using Xunit;

public class TaskServiceTests
{
    [Fact]
    public void AddTask_ValidTitle_ReturnsSuccess()
    {
        // Arrange
        var service = new TaskService();

        // Act
        var result = service.AddTask("Test Task");
        var tasklist = service.GetAllTasks();

        // Assert
        Assert.Equal(AddTaskResult.Success, result);
        Assert.Single(tasklist);
        Assert.Equal("Test Task", tasklist.First().Title);
    }

    [Fact]

    public void AddTask_MultipleTasks_ListContainsAll()
    {
        // Arrange
        var service = new TaskService();

        // Act
        service.AddTask("Title1");
        service.AddTask("Title2");
        var result = service.GetAllTasks().Count();

        // Assert
        Assert.Equal(2, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void AddTask_EmptyTitle_ReturnsEmptyTitle(string title)
    {
        // Arrange
        var service = new TaskService();

        // Act
        var result = service.AddTask(title);

        // Assert
        Assert.Equal(AddTaskResult.EmptyTitle, result);
    }

    [Theory]
    [InlineData("Task")]
    [InlineData("task")]
    [InlineData("TASK")]
    public void AddTask_DuplicateTitle_ReturnsDuplicateTitle(string secondTitle)
    {
        var service = new TaskService();

        service.AddTask("Task");
        var result = service.AddTask(secondTitle);

        Assert.Equal(AddTaskResult.DuplicateTitle, result);
    }

    [Fact]
    public void RemoveTask_ValidId_ReturnsTrue()
    {
        var service = new TaskService();

        service.AddTask("Test Task");
        var task = service.GetAllTasks().First(); //in case later we calculate ids differently, we get the actual id of the task we just added
        var result = service.RemoveTask(task.Id);
        Assert.True(result);
        Assert.Empty(service.GetAllTasks());


    }

    [Fact]
    public void RemoveTask_NonexistingId_ReturnsFalse()
    {
        // Arrange
        var service = new TaskService();

        // Act
        var result1 = service.RemoveTask(1);

        // Assert
        Assert.False(result1);
    }


}