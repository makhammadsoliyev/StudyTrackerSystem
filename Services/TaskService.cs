using StudyTrackerSystem.Interfaces;
using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Services;

public class TaskService : ITaskService
{
    private readonly List<TaskModel> tasks;

    public TaskService()
    {
        tasks = new List<TaskModel>();
    }

    public TaskModel Create(TaskModel task)
    {
        tasks.Add(task);
        return task;
    }

    public bool Delete(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id)
            ?? throw new Exception("Task with this id was not found...");

        return tasks.Remove(task);
    }

    public List<TaskModel> GetAll()
        => tasks;

    public TaskModel GetById(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id)
            ?? throw new Exception("Task with this id was not found...");

        return task;
    }

    public List<TaskModel> GetTasksOrderByDeadline()
        => tasks.OrderBy(t => t.Deadline).ToList();

    public TaskModel Update(int id, TaskModel task)
    {
        var existTask = tasks.FirstOrDefault(t => t.Id == id)
            ?? throw new Exception("Task with this id was not found...");

        existTask.Id = id;
        existTask.Title = task.Title;
        existTask.Points = task.Points;
        existTask.Deadline = task.Deadline;
        existTask.Description = task.Description;

        return existTask;
    }
}
