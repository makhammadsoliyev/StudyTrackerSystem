using Spectre.Console;
using StudyTrackerSystem.Models;
using StudyTrackerSystem.Services;

namespace StudyTrackerSystem.Display;

public class TaskMenu
{
    #region
    private readonly TaskService taskService;
    #endregion

    #region CTOR
    public TaskMenu(TaskService taskService)
    {
        this.taskService = taskService;
    }
    #endregion

    #region Methods
    private void Create()
    {
        string title = AnsiConsole.Ask<string>("[blue]Title: [/]");
        string description = AnsiConsole.Ask<string>("[red]Description: [/]");
        DateTime deadline = AnsiConsole.Ask<DateTime>("[green]Deadline 'dd/mm/yyyy HH:mm(Pm/Am)': [/]");
        decimal point = AnsiConsole.Ask<decimal>("[yellow]Point: [/]");
        while (point <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            point = AnsiConsole.Ask<decimal>("[yellow]Point: [/]");
        }

        var task = new TaskModel()
        {
            Title = title,
            Description = description,
            Deadline = deadline,
            Points = point
        };

        var addedTask = taskService.Create(task);
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
            var task = taskService.GetById(id);
            var table = new Selection().DataTable("Task", task);
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
            var isDeleted = taskService.Delete(id);
            AnsiConsole.MarkupLine("[green]Successfully deleted...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
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
        DateTime deadline = AnsiConsole.Ask<DateTime>("[green]Deadline 'dd/mm/yyyy HH:mm(Pm/Am)': [/]");
        decimal point = AnsiConsole.Ask<decimal>("[yellow]Point: [/]");
        while (point <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input.[/]");
            point = AnsiConsole.Ask<decimal>("[yellow]Point: [/]");
        }

        var task = new TaskModel()
        {
            Title = title,
            Description = description,
            Deadline = deadline,
            Points = point
        };

        try
        {
            var updatedTask = taskService.Update(id, task);
            AnsiConsole.MarkupLine("[green]Successfully updated...[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
        Thread.Sleep(1500);
    }

    private void GetAll()
    {
        var tasks = taskService.GetAll().ToArray();
        var table = new Selection().DataTable("Tasks", tasks);
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[blue]Enter to continue...[/]");
        Console.ReadKey();
    }

    public void GetTasksOrderByDeadline()
    {
        var tasks = taskService.GetTasksOrderByDeadline().ToArray();
        var table = new Selection().DataTable("Tasks Ordered by Deadline", tasks);
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[blue]Enter to continue...[/]");
        Console.ReadKey();
    }

    public void Display()
    {
        var circle = true;
        var selectionDisplay = new Selection();
        var options = new string[] { "Create", "GetById", "Update", "Delete", "GetAll", "GetTasksOrderByDeadline", "Back" };
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
                case "GetTasksOrderByDeadline":
                    GetTasksOrderByDeadline();
                    break;
                case "Back":
                    circle = false;
                    break;
            }
        }
    }
    #endregion
}
