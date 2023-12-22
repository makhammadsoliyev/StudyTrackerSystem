using StudyTrackerSystem.Interfaces;
using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Services;

public class StudentService : IStudentService
{
    #region Private fields
    private readonly List<Student> students;
    #endregion

    #region CTOR
    public StudentService()
    {
        students = new List<Student>();
    }
    #endregion

    #region Methods
    public Student Create(Student student)
    {
        var existStudent = students.FirstOrDefault(s => s.Phone.Equals(student.Phone));
        if (existStudent is not null)
            throw new Exception("Student with this phone number already exists...");

        students.Add(student);
        return student;
    }

    public bool Delete(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id)
            ?? throw new Exception("Student with this id was not found...");

        return students.Remove(student);
    }

    public List<Student> GetAll()
        => students;

    public Student GetById(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id)
            ?? throw new Exception("Student with this id was not found...");

        return student;
    }

    public List<Student> GetStudentsRanking()
        => students.OrderBy(s => s.Points).ToList();

    public Student Update(int id, Student student)
    {
        var existStudent = students.FirstOrDefault(s => s.Id == id)
            ?? throw new Exception("Student with this id was not found...");

        existStudent.Id = id;
        existStudent.Phone = student.Phone;
        existStudent.LastName = student.LastName;
        existStudent.FirstName = student.FirstName;

        return existStudent;
    }
    #endregion
}
