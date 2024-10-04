using StudentManagementApi.Models;

namespace StudentManagementApi.Interfaces;

public interface IStudentService
{
    Student? GetStudentById(int id);
    void CreateStudent(Student student);
    void UpdateStudent(int id, Student updatedStudent);
    void DeleteStudent(int id);
}