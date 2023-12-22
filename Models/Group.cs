namespace StudyTrackerSystem.Models;

public class Group
{
    #region Private fields
    private static int id = 0;
    #endregion

    #region CTOR
    public Group()
    {
        Id = ++id;
    }
    #endregion

    #region Properties
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int GroupId { get; set; }
    public int MentorId { get; set; }
    public List<Student> Students { get; set; }
    #endregion
}
