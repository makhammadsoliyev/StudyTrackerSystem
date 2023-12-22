namespace StudyTrackerSystem.Models;

public class Mentor
{
    #region Private fields
    private static int id = 0;
    #endregion

    #region CTOR
    public Mentor()
    {
        Id = ++id;
    }
    #endregion

    #region Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Course { get; set; }
    #endregion
}
