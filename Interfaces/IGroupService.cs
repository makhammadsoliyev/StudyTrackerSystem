using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Interfaces;

public interface IGroupService
{
    Group Create(Group group);
    Group GetByID(int id);
    Group Update(int id, Group group);
    bool Delete(int id);
    List<Group> GetAll();
    List<Student> GetStudentsFromGroup(int id);
    Student AddStudent(int groupId, int studentId);
    bool DeleteStudent(int groupId, int studentId);
    Mentor AddMentor(int groupId, int mentorId);
    bool DeleteMentor(int groupId, int mentorId);
}
