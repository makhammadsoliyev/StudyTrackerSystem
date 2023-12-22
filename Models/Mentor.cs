namespace StudyTrackerSystem.Models;

public class Mentor
{
    private static int id = 0;

    public Mentor()
    {
        Id = ++id;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Course { get; set; }
}
