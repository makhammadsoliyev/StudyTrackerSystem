namespace StudyTrackerSystem.Models;

public class Student
{
    #region Private fields
    private static int id = 0;
    #endregion

    #region CTOR
    public Student()
    {
        Id = ++id;
    }
    #endregion

    #region Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public decimal Points { get; set; }
    public List<TaskModel> Tasks { get; set; }
    #endregion
}