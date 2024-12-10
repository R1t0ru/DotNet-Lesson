using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new()
        {
            new() {AdmissionDate = new DateTime(2024,09,11),Firstname = "John", Lastname = "Doe", Age = 25},
            new() {AdmissionDate = new DateTime(2024,09,11),Firstname = "Max", Lastname = "Staz", Age = 22},
            new() {AdmissionDate = new DateTime(2024,09,11),Firstname = "Max", Lastname = "Vyes", Age = 23}
        };

        // GET: StudentController
        public IActionResult Index()
        {
            // var student = new Student();
            // student.Id = 1;
            // student.Firstname = "John";
            // student.Lastname = "James";
            // student.Age = 20;
            // student.GPA = 3.5;
            // student.Major = Major.CS;
            // student.AdmissionDate = new DateTime(2024, 09, 02);
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Max(e => e.Id) + 1;
                students.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
