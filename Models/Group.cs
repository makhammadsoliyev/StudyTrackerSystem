namespace StudyTrackerSystem.Models;

public class Group
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int GroupId { get; set; }
    public int MentorId { get; set; }
    public List<Student> students { get; set; }
}
