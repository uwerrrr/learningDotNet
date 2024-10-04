using StudentManagementApi.Interfaces;
using StudentManagementApi.Models;

namespace StudentManagementApi.Services;

public class StudentService : IStudentService
{
    private readonly List<Student> _students = new List<Student>();

    public Student? GetStudentById(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public void CreateStudent(Student student)
    {
        _students.Add(student);
    }

    public void UpdateStudent(int id, Student updatedStudent)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);

        if (student == null) return;

        student.Name = updatedStudent.Name;
        student.Age = updatedStudent.Age;
    }

    public void DeleteStudent(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            _students.Remove(student);
        }
    }
}
