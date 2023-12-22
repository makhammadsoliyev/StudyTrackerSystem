using Spectre.Console;
using StudyTrackerSystem.Models;
using StudyTrackerSystem.Services;

namespace StudyTrackerSystem.Display;

public class GroupMenu
{
    #region Private fields
    private readonly GroupService groupService;
    #endregion

    #region CTOR
    public GroupMenu(GroupService groupService)
    {
        this.groupService = groupService;
    }
    #endregion

    #region Methods
    private void Create()
    {
        string title = AnsiConsole.Ask<string>("[blue]Title: [/]");
        string description = AnsiConsole.Ask<string>("[red]Description: [/]");

        var group = new Group()
        {
            Title = title,
            Description = description,
            Students = new List<Student>(),
            MentorId = 0
        };

        var addedGroup = groupService.Create(group);
        AnsiConsole.MarkupLine($"[green]Successfully created...[/]");
        Thread.Sleep(1500);
    }

    private void GetById()
    {
        int id = AnsiConsole.Ask<int>("[aqua]Id: [/]");
        while (id <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            id = AnsiConsole.Ask<int>("[aqua]Id: [/]");
        }

        try
        {
            var group = groupService.GetById(id);
            var table = new Selection().DataTable("Group", group);
            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("[blue]Enter to continue...[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            Thread.Sleep(1500);
        }
    }

    private void Update()
    {
        int id = AnsiConsole.Ask<int>("[aqua]Id: [/]");
        while (id <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            id = AnsiConsole.Ask<int>("[aqua]Id: [/]");
        }

        string title = AnsiConsole.Ask<string>("[blue]Title: [/]");
        string description = AnsiConsole.Ask<string>("[red]Description: [/]");

        var group = new Group()
        {
            Title = title,
            Description = description,
            Students = new List<Student>(),
        };

        try
        {
            var updatedGroup = groupService.Update(id, group);
            AnsiConsole.MarkupLine("[green]Successfully updated...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
    }

    private void Delete()
    {
        int id = AnsiConsole.Ask<int>("[aqua]Id: [/]");
        while (id <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            id = AnsiConsole.Ask<int>("[aqua]Id: [/]");
        }

        try
        {
            var isDeleted = groupService.Delete(id);
            AnsiConsole.MarkupLine("[green]Successfully deleted...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
    }

    private void GetAll()
    {
        var groups = groupService.GetAll().ToArray();
        var table = new Selection().DataTable("Groups", groups);
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[blue]Enter to continue...[/]");
        Console.ReadKey();
    }

    private void AddStudent()
    {
        int groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        while (groupId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        }

        int studentId = AnsiConsole.Ask<int>("[aqua]StudentId: [/]");
        while (studentId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            studentId = AnsiConsole.Ask<int>("[aqua]StudentId: [/]");
        }

        try
        {
            var student = groupService.AddStudent(groupId, studentId);
            AnsiConsole.MarkupLine("[green]Successfully student added...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
    }

    private void DeleteStudent()
    {
        int groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        while (groupId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        }

        int studentId = AnsiConsole.Ask<int>("[aqua]StudentId: [/]");
        while (studentId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            studentId = AnsiConsole.Ask<int>("[aqua]StudentId: [/]");
        }

        try
        {
            var isDeleted = groupService.AddStudent(groupId, studentId);
            AnsiConsole.MarkupLine("[green]Successfully student deleted...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
    }

    private void AddMentor()
    {
        int groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        while (groupId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        }

        int mentorId = AnsiConsole.Ask<int>("[aqua]MentorId: [/]");
        while (mentorId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            mentorId = AnsiConsole.Ask<int>("[aqua]MentorId: [/]");
        }

        try
        {
            var mentor = groupService.AddMentor(groupId, mentorId);
            AnsiConsole.MarkupLine("[green]Successfully mentor added...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
    }

    private void DeleteMentor()
    {
        int groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        while (groupId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        }

        int mentorId = AnsiConsole.Ask<int>("[aqua]MentorId: [/]");
        while (mentorId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            mentorId = AnsiConsole.Ask<int>("[aqua]MentorId: [/]");
        }

        try
        {
            var isDeleted = groupService.DeleteMentor(groupId, mentorId);
            AnsiConsole.MarkupLine("[green]Successfully mentor deleted...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
    }

    private void GetStudentsFromGroup()
    {
        int groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        while (groupId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            groupId = AnsiConsole.Ask<int>("[aqua]GroupId: [/]");
        }

        try
        {
            var students = groupService.GetStudentsFromGroup(groupId).ToArray();

            var table = new Selection().DataTable($"GroupId: {groupId}", students);
            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("[blue]Enter to continue...[/]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            Thread.Sleep(1500);
        }
    }

    public void Display()
    {
        var circle = true;
        var selectionDisplay = new Selection();
        var options = new string[] { "Create", "GetById", "Update", "Delete", "GetAll", "AddStudent", "DeleteStudent",
            "AddMentor", "DeleteMentor", "GetStudentsFromGroup", "Back" };
        var title = "Choose one of options";

        while (circle)
        {
            AnsiConsole.Clear();
            var selection = selectionDisplay.ShowSelectionMenu(title, options);
            switch (selection)
            {
                case "Create":
                    Create();
                    break;
                case "GetById":
                    GetById();
                    break;
                case "Update":
                    Update();
                    break;
                case "Delete":
                    Delete();
                    break;
                case "GetAll":
                    GetAll();
                    break;
                case "AddStudent":
                    AddStudent();
                    break;
                case "DeleteStudent":
                    DeleteStudent();
                    break;
                case "AddMentor":
                    AddMentor();
                    break;
                case "DeleteMentor":
                    DeleteMentor();
                    break;
                case "GetStudentsFromGroup":
                    GetStudentsFromGroup();
                    break;
                case "Back":
                    circle = false;
                    break;
            }
        }
    }
    #endregion
}
