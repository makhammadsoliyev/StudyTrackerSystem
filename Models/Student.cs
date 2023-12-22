namespace StudyTrackerSystem.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public decimal Points { get; set; }
    public List<TaskModel> Tasks { get; set; }
}