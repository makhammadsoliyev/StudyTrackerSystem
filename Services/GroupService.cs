using StudyTrackerSystem.Interfaces;
using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Services;

public class GroupService : IGroupService
{
    private readonly MentorService mentorService;
    private readonly StudentService studentService;
    private readonly List<Group> groups;

    public GroupService(MentorService mentorService, StudentService studentService)
    {
        this.mentorService = mentorService;
        this.studentService = studentService;
        this.groups = new List<Group>();
    }

    public Mentor AddMentor(int groupId, int mentorId)
    {
        var group = groups.FirstOrDefault(g => g.GroupId == groupId)
            ?? throw new Exception("Group with this id was not found...");

        var mentor = mentorService.GetById(mentorId);

        group.MentorId = mentorId;
        mentor.GroupId = groupId;

        return mentor;
    }

    public bool DeleteMentor(int groupId, int mentorId)
    {
        var group = groups.FirstOrDefault(g => g.GroupId == groupId)
            ?? throw new Exception("Group with this id was not found...");

        var mentor = mentorService.GetById(mentorId);

        group.MentorId = 0;
        mentor.GroupId = 0;

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

        group.students.Add(student);

        return student;
    }

    public bool DeleteStudent(int groupId, int studentId)
    {
        var group = groups.FirstOrDefault(g => g.GroupId == groupId)
            ?? throw new Exception("Group with this id was not found...");

        var student = studentService.GetById(studentId);
        student.GroupId = 0;

        return group.students.Remove(student);
    }

    public bool Delete(int id)
    {
        var group = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");
        //group.students.ForEach(student => student.GroupId = 0);
        var students = studentService.GetAll().Where(s => s.GroupId == id).ToList();
        students.ForEach(s => s.GroupId = 0);

        var mentor = mentorService.GetById(group.MentorId);
        mentor.GroupId = 0;

        return groups.Remove(group);
    }

    public List<Group> GetAll()
        => groups;

    public Group GetByID(int id)
    {
        var group = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        return group;
    }

    public List<Student> GetStudentsFromGroup(int id)
    {
        var group = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        return group.students;
    }

    public Group Update(int id, Group group)
    {
        var existGroup = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        existGroup.Title = group.Title;
        existGroup.Description = group.Description;

        return existGroup;
    }
}
