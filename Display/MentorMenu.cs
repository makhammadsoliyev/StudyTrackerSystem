using Spectre.Console;
using StudyTrackerSystem.Models;
using StudyTrackerSystem.Services;

namespace StudyTrackerSystem.Display;

public class MentorMenu
{
    #region Private fields
    private readonly MentorService mentorService;
    #endregion

    #region CTOR
    public MentorMenu(MentorService mentorService)
    {
        this.mentorService = mentorService;
    }
    #endregion

    #region Methods
    private void Create()
    {
        string firstName = AnsiConsole.Ask<string>("[blue]FirstName: [/]");
        string lastName = AnsiConsole.Ask<string>("[cyan2]LastName: [/]");
        string course = AnsiConsole.Ask<string>("[yellow]Course: [/]");

        var mentor = new Mentor()
        {
            FirstName = firstName,
            LastName = lastName,
            Course = course
        };

        var addedMentor = mentorService.Create(mentor);
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
            var mentor = mentorService.GetById(id);
            var table = new Selection().DataTable("Mentor", mentor);
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

        string firstName = AnsiConsole.Ask<string>("[blue]FirstName: [/]");
        string lastName = AnsiConsole.Ask<string>("[cyan2]LastName: [/]");
        string course = AnsiConsole.Ask<string>("[yellow]Course: [/]");

        var mentor = new Mentor()
        {
            FirstName = firstName,
            LastName = lastName,
            Course = course
        };

        try
        {
            var updatedMentor = mentorService.Update(id, mentor);
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
            var isDeleted = mentorService.Delete(id);
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
        var mentors = mentorService.GetAll().ToArray();
        var table = new Selection().DataTable("Mentors", mentors);
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[blue]Enter to continue...[/]");
        Console.ReadKey();
    }

    private void GiveTaskToStudent()
    {
        int studentId = AnsiConsole.Ask<int>("[aqua]StudentId: [/]");
        while (studentId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            studentId = AnsiConsole.Ask<int>("[aqua]StudentId: [/]");
        }

        int taskId = AnsiConsole.Ask<int>("[aqua]TaskId: [/]");
        while (taskId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            taskId = AnsiConsole.Ask<int>("[aqua]TaskId: [/]");
        }

        try
        {
            var task = mentorService.GiveTaskToStudent(studentId, taskId);
            AnsiConsole.MarkupLine("[green]Successfully task given...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
    }

    private void MarkStudent()
    {
        int studentId = AnsiConsole.Ask<int>("[aqua]StudentId: [/]");
        while (studentId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            studentId = AnsiConsole.Ask<int>("[aqua]StudentId: [/]");
        }

        int taskId = AnsiConsole.Ask<int>("[aqua]TaskId: [/]");
        while (taskId <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            taskId = AnsiConsole.Ask<int>("[aqua]TaskId: [/]");
        }

        try
        {
            var task = mentorService.MarkStudent(studentId, taskId);
            AnsiConsole.MarkupLine("[green]Successfully marked...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
    }

    public void Display()
    {
        var circle = true;
        var selectionDisplay = new Selection();
        var options = new string[] { "Create", "GetById", "Update", "Delete", "GetAll", "GiveTaskToStudent", "MarkStudent", "Back" };
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
                case "GiveTaskToStudent":
                    GiveTaskToStudent();
                    break;
                case "MarkStudent":
                    MarkStudent();
                    break;
                case "Back":
                    circle = false;
                    break;
            }
        }
    }
    #endregion
}
