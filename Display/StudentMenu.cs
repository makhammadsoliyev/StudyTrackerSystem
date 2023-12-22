using Spectre.Console;
using StudyTrackerSystem.Models;
using StudyTrackerSystem.Services;
using System.Text.RegularExpressions;

namespace StudyTrackerSystem.Display;

public class StudentMenu
{
    private readonly StudentService studentService;

    public StudentMenu(StudentService studentService)
    {
        this.studentService = studentService;
    }

    public void Create()
    {
        string firstName = AnsiConsole.Ask<string>("[blue]FirstName: [/]");
        string lastName = AnsiConsole.Ask<string>("[cyan2]LastName: [/]");
        string phone = AnsiConsole.Ask<string>("[cyan1]Phone(+998XXxxxxxxx): [/]");
        while (!Regex.IsMatch(phone, @"^\+998\d{9}$"))
        {
            AnsiConsole.MarkupLine("[red]Invalid input.[/]");
            phone = AnsiConsole.Ask<string>("[cyan1]Phone(+998XXxxxxxxx): [/]");
        }

        var student = new Student()
        {
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            Points = 0.0m,
            Tasks = new List<TaskModel>()
        };

        try
        {
            var addedStudent = studentService.Create(student);
            AnsiConsole.MarkupLine("[green]Successfully created...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
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
            var student = studentService.GetById(id);
            var table = new Selection().DataTable("Student", student);
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
        string phone = AnsiConsole.Ask<string>("[cyan1]Phone(+998XXxxxxxxx): [/]");
        while (!Regex.IsMatch(phone, @"^\+998\d{9}$"))
        {
            AnsiConsole.MarkupLine("[red]Invalid input.[/]");
            phone = AnsiConsole.Ask<string>("[cyan1]Phone(+998XXxxxxxxx): [/]");
        }

        var student = new Student()
        {
            FirstName = firstName,
            LastName = lastName,
            Phone = phone
        };

        try
        {
            var updatedStudent = studentService.Update(id, student);
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
            var isDeleted = studentService.Delete(id);
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
        var students = studentService.GetAll().ToArray();
        var table = new Selection().DataTable("Students", students);
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[blue]Enter to continue...[/]");
        Console.ReadKey();
    }

    private void GetStudentsRanking()
    {
        var students = studentService.GetStudentsRanking().ToArray();
        var table = new Selection().DataTable("Ranking of Students", students);
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[blue]Enter to continue...[/]");
        Console.ReadKey();
    }

    public void Display()
    {
        var circle = true;
        var selectionDisplay = new Selection();
        var options = new string[] { "Create", "GetById", "Update", "Delete", "GetAll", "GetStudentsRanking", "Back" };
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
                case "GetStudentsRanking":
                    GetStudentsRanking();
                    break;
                case "Back":
                    circle = false;
                    break;
            }
        }
    }
}
