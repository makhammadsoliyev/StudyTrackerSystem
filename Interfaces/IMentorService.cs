using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Interfaces;

public interface IMentorService
{
    Mentor Create(Mentor mentor);
    Mentor GetById(int id);
    Mentor Update(int id, Mentor mentor);
    bool Delete(int id);
    List<Mentor> GetAll();
    TaskModel GiveTaskToGroup(int groupId, int taskId);
    Student MarkStudent(int groupId, int studentId, int taskId);
    List<Student> GetStudentsOfMentor(int id);
}
