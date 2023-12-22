using StudyTrackerSystem.Interfaces;
using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Services;

public class MentorService : IMentorService
{
    private readonly StudentService studentService;
    private readonly TaskService taskService;
    private readonly List<Mentor> mentors;

    public MentorService()
    {
        this.mentors = new List<Mentor>();
        this.taskService = new TaskService();
        this.studentService = new StudentService();
    }

    public Mentor Create(Mentor mentor)
    {
        mentors.Add(mentor);
        return mentor;
    }

    public bool Delete(int id)
    {
        var mentor = mentors.FirstOrDefault(m => m.Id == id)
            ?? throw new Exception("Mentor with this id was not found...");

        return mentors.Remove(mentor);
    }

    public List<Mentor> GetAll()
        => mentors;

    public Mentor GetById(int id)
    {
        var mentor = mentors.FirstOrDefault(m => m.Id == id)
            ?? throw new Exception("Mentor with this id was not found...");

        return mentor;
    }

    public TaskModel GiveTaskToStudent(int studentId, int taskId)
    {
        var student = studentService.GetById(studentId);
        var task = taskService.GetById(taskId);

        student.Tasks.Add(task);

        return task;
    }

    public Student MarkStudent(int studentId, int taskId)
    {
        var student = studentService.GetById(studentId);
        var task = student.Tasks.FirstOrDefault(task => task.Id == taskId)
            ?? throw new Exception("This task was not given to this student...");

        student.Tasks.Remove(task);
        student.Points += task.Points;

        return student;
    }

    public Mentor Update(int id, Mentor mentor)
    {
        var existMentor = mentors.FirstOrDefault(m => m.Id == id)
            ?? throw new Exception("Mentor with this id was not found...");

        existMentor.Id = id;
        existMentor.Course = existMentor.Course;
        existMentor.LastName = existMentor.LastName;
        existMentor.FirstName = existMentor.FirstName;

        return existMentor;
    }
}
