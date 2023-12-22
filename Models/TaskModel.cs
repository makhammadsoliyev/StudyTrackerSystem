namespace StudyTrackerSystem.Models;

public class TaskModel
{
    #region Private fields
    private static int id = 0;
    #endregion

    #region CTOR
    public TaskModel()
    {
        Id = ++id;
    }
    #endregion

    #region Properties
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public decimal Points { get; set; }
    #endregion
}
