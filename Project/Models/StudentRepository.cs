using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class StudentRepository : IStudentRepository
    {
          private readonly HostelMSDbContext _hostelMSDbContext;
        public StudentRepository(HostelMSDbContext hostelMSDbContext)
        {
            _hostelMSDbContext = hostelMSDbContext;
        }
        public IEnumerable<Student> AllStudents
        {
            get
            {
                return _hostelMSDbContext.Students;
            }
        }
        public void AddStudent(Student student)
        {
            _hostelMSDbContext.Students.Add(student);
            _hostelMSDbContext.SaveChanges();
        }
        public Student? GetStudentById(int StudentId)
        {
            return _hostelMSDbContext.Students.FirstOrDefault(p => p.StudentId == StudentId);
        }
        public void UpdateStudent(Student student)
        {
            var existingStudent = _hostelMSDbContext.Students.FirstOrDefault(p => p.StudentId == student.StudentId);
            if (existingStudent == null)
            {
                throw new Exception("Books not  found");
            }
            existingStudent.Name = student.Name;
            existingStudent.Details = student.Details;
            existingStudent.ImageUrl = student.ImageUrl;

            _hostelMSDbContext.Entry(existingStudent).State = EntityState.Modified;
            _hostelMSDbContext.SaveChanges();
        }
        public void DeleteStudent(int StudentId)
        {

            var student = _hostelMSDbContext.Students.Find(StudentId);

            if (student == null)
            {
                throw new ArgumentException("Books  not found");
            }


            _hostelMSDbContext.Students.Remove(student);
            _hostelMSDbContext.SaveChanges();

        }
    }
}
