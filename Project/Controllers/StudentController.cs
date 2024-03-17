using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.ViewModel;

namespace Project.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            StudentListViewModel libraryListViewModels = new StudentListViewModel(_studentRepository.AllStudents);
            return View(libraryListViewModels);
        }
        public IActionResult AddStudent()
        {
            var viewModels = new AddStudentViewModel();
            return View(viewModels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(AddStudentViewModel viewModels)
        {
            Student newStudent = new Student
            {
                StudentId = viewModels.StudentId,
                Name = viewModels.Name,
                Details = viewModels.Details,
                ImageUrl = viewModels.ImageUrl,
            };
            _studentRepository.AddStudent(newStudent);
            return RedirectToAction("List");
        }
        [HttpGet]

        public ActionResult UpdateStudent(int id)
        {
            var Student = _studentRepository.GetStudentById(id);
            var updateStudentViewModel = new UpdateStudentViewModel
            {
                StudentId = Student.StudentId,
                Name = Student.Name,
                Details = Student.Details,
                ImageUrl = Student.ImageUrl,
            };

            return View(updateStudentViewModel);
        }
        [HttpPost]

        public ActionResult UpdateStudent(AddStudentViewModel viewModels)
        {
            Student newStudent = new Student
            {
                StudentId = viewModels.StudentId,
                Name = viewModels.Name,
                Details = viewModels.Details,
                ImageUrl = viewModels.ImageUrl,
            };
            _studentRepository.UpdateStudent(newStudent);
            return RedirectToAction("List");
        }
        public IActionResult DeleteStudent(int Id)
        {

            _studentRepository.DeleteStudent(Id);

            return RedirectToAction("List");


        }

    }
}
