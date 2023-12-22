using StudyTrackerSystem.Interfaces;
using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Services;

public class GroupService : IGroupService
{
    #region Private fields
    private readonly MentorService mentorService;
    private readonly StudentService studentService;
    private readonly List<Group> groups;
    #endregion

    #region CTOR
    public GroupService(MentorService mentorService, StudentService studentService)
    {
        this.mentorService = mentorService;
        this.studentService = studentService;
        this.groups = new List<Group>();
    }
    #endregion

    #region Methods
    public Mentor AddMentor(int groupId, int mentorId)
    {
        var group = groups.FirstOrDefault(g => g.GroupId == groupId)
            ?? throw new Exception("Group with this id was not found...");

        var mentor = mentorService.GetById(mentorId);

        group.MentorId = mentorId;

        return mentor;
    }

    public bool DeleteMentor(int groupId, int mentorId)
    {
        var group = groups.FirstOrDefault(g => g.GroupId == groupId)
            ?? throw new Exception("Group with this id was not found...");

        var mentor = mentorService.GetById(mentorId);

        group.MentorId = 0;

        return true;
    }

    public Group Create(Group group)
    {
        groups.Add(group);
        return group;
    }

    public Student AddStudent(int groupId, int studentId)
    {
        var group = groups.FirstOrDefault(g => g.GroupId == groupId)
            ?? throw new Exception("Group with this id was not found...");

        var student = studentService.GetById(studentId);

        group.Students.Add(student);

        return student;
    }

    public bool DeleteStudent(int groupId, int studentId)
    {
        var group = groups.FirstOrDefault(g => g.GroupId == groupId)
            ?? throw new Exception("Group with this id was not found...");

        var student = studentService.GetById(studentId);

        return group.Students.Remove(student);
    }

    public bool Delete(int id)
    {
        var group = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        return groups.Remove(group);
    }

    public List<Group> GetAll()
        => groups;

    public Group GetById(int id)
    {
        var group = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        return group;
    }

    public List<Student> GetStudentsFromGroup(int id)
    {
        var group = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        return group.Students;
    }

    public Group Update(int id, Group group)
    {
        var existGroup = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        existGroup.Title = group.Title;
        existGroup.Description = group.Description;

        return existGroup;
    }
    #endregion
}
