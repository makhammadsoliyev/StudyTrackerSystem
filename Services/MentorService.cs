using StudyTrackerSystem.Interfaces;
using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Services;

public class MentorService : IMentorService
{
    private readonly List<Mentor> mentors;

    public MentorService()
    {
        mentors = new List<Mentor>();
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

    public List<Student> GetStudentsOfMentor(int id)
    {
        var mentor = mentors.FirstOrDefault(mentors => mentors.Id == id)
            ?? throw new Exception("Mentor with this id was not found...");


    }

    public TaskModel GiveTaskToGroup(int groupId, int taskId)
    {
        throw new NotImplementedException();
    }

    public Student MarkStudent(int groupId, int studentId, int taskId)
    {
        throw new NotImplementedException();
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
