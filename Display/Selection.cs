using Spectre.Console;
using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Display;

public class Selection
{
    public Table DataTable(string title, params TaskModel[] tasks)
    {
        var table = new Table();

        table.Title(title.ToUpper())
            .BorderColor(Color.Blue)
            .AsciiBorder();

        table.AddColumn("ID");
        table.AddColumn("Title");
        table.AddColumn("Description");
        table.AddColumn("Deadline");
        table.AddColumn("Point");

        foreach (var task in tasks)
        {
            table.AddRow(task.Id.ToString(), task.Title, task.Description, task.Deadline.ToString(), task.Points.ToString());
        }

        return table;
    }

    public Table DataTable(string title, params Student[] students)
    {
        var table = new Table();

        table.Title(title.ToUpper())
            .BorderColor(Color.Blue)
            .AsciiBorder();

        table.AddColumn("ID");
        table.AddColumn("FirstName");
        table.AddColumn("LastName");
        table.AddColumn("Phone");
        table.AddColumn("Point");
        table.AddColumn("Active Tasks");


        foreach (var student in students)
        {
            table.AddRow(student.Id.ToString(), student.FirstName, student.LastName, student.Phone,
                student.Points.ToString(), string.Join(", ", student.Tasks.Select(t => $"{t.Id} {t.Title}")));
        }

        return table;
    }

    public Table DataTable(string title, params Mentor[] mentors)
    {
        var table = new Table();

        table.Title(title.ToUpper())
            .BorderColor(Color.Blue)
            .AsciiBorder();

        table.AddColumn("ID");
        table.AddColumn("FirstName");
        table.AddColumn("LastName");
        table.AddColumn("Course");

        foreach (var mentor in mentors)
        {
            table.AddRow(mentor.Id.ToString(), mentor.FirstName, mentor.LastName, mentor.Course);
        }

        return table;
    }

    public Table DataTable(string title, params Group[] groups)
    {
        var table = new Table();

        table.Title(title.ToUpper())
            .BorderColor(Color.Blue)
            .AsciiBorder();

        table.AddColumn("ID");
        table.AddColumn("Title");
        table.AddColumn("Description");
        table.AddColumn("Number of Students");
        table.AddColumn("MentorId");

        foreach (var group in groups)
        {
            table.AddRow(group.Id.ToString(), group.Title, group.Description,
                group.Students.Count.ToString(), group.MentorId == 0 ? "No Mentor" : group.MentorId.ToString());
        }

        return table;
    }

    public string ShowSelectionMenu(string title, string[] options)
    {
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .PageSize(5) // Number of items visible at once
                .AddChoices(options)
                .HighlightStyle(new Style(foreground: Color.White, background: Color.Blue))
        );

        return selection;
    }
}
