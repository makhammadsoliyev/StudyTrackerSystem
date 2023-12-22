using StudyTrackerSystem.Services;

namespace StudyTrackerSystem.Display;

public class MainMenu
{
    #region Private Fields Sub Menus
    private readonly TaskMenu taskMenu;
    private readonly GroupMenu groupMenu;
    private readonly MentorMenu mentorMenu;
    private readonly StudentMenu studentMenu;
    #endregion

    #region Private Fields Services
    private readonly TaskService taskService;
    private readonly GroupService groupService;
    private readonly MentorService mentorService;
    private readonly StudentService studentService;
    #endregion

    #region CTOR
    public MainMenu()
    {
        this.taskService = new TaskService();
        this.studentService = new StudentService();
        this.mentorService = new MentorService(studentService, taskService);
        this.groupService = new GroupService(mentorService, studentService);

        this.taskMenu = new TaskMenu(taskService);
        this.groupMenu = new GroupMenu(groupService);
        this.mentorMenu = new MentorMenu(mentorService);
        this.studentMenu = new StudentMenu(studentService);
    }
    #endregion

    #region Main method
    public void Main()
    {
        var circle = true;
        var selectionDisplay = new Selection();

        while (circle)
        {
            var selection = selectionDisplay.ShowSelectionMenu("Choose one of options", new string[] { "Tasks", "Students", "Mentors", "Groups", "Exit" });
            switch (selection)
            {
                case "Tasks":
                    taskMenu.Display();
                    break;
                case "Students":
                    studentMenu.Display();
                    break;
                case "Mentors":
                    mentorMenu.Display();
                    break;
                case "Groups":
                    groupMenu.Display();
                    break;
                case "Exit":
                    circle = false;
                    break;
            }
        }
    }
    #endregion
}
