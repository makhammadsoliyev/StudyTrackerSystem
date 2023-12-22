namespace StudyTrackerSystem.Models;

public class Student
{
    private static int id = 0;

    public Student()
    {
        Id = ++id;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public decimal Points { get; set; }
    public List<TaskModel> Tasks { get; set; }
}