
namespace Project.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> AllStudents { get; }
        Student? GetStudentById(int studentId);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int StudentId);

    }
}
