using Project.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project.ViewModel
{
    public class StudentListViewModel
    {
        public IEnumerable<Student> Students { get; }

        public StudentListViewModel(IEnumerable<Student> students)
        {
            Students = students;
        }
    }
}
