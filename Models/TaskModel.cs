namespace StudyTrackerSystem.Models;

public class TaskModel
{
    private static int id = 0;

    public TaskModel()
    {
        Id = ++id;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public decimal Points { get; set; }
}
