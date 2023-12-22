using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Interfaces;

public interface IMentorService
{
    #region Methods
    Mentor Create(Mentor mentor);
    Mentor GetById(int id);
    Mentor Update(int id, Mentor mentor);
    bool Delete(int id);
    List<Mentor> GetAll();
    TaskModel GiveTaskToStudent(int student, int taskId);
    Student MarkStudent(int studentId, int taskId);
    #endregion
}
